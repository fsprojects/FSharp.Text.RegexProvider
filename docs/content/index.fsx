(*** hide ***)
#I "../../bin/netstandard2.0"

(**
FSharp.Text.RegexProvider
===========================

The FSharp.Text.RegexProvider project contains a type provider for regular expressions.

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The library can be <a href="https://nuget.org/packages/FSharp.Text.RegexProvider">installed from NuGet</a>:
      <pre>PM> Install-Package FSharp.Text.RegexProvider</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

Example
-------

This example demonstrates the use of the type provider:

*)
// reference the type provider dll
#r "FSharp.Text.RegexProvider.dll"
open System.Globalization
open FSharp.Text.RegexProvider

// Let the type provider do its work
type PhoneRegex = Regex< @"(?<AreaCode>^\d{3})-(?<PhoneNumber>\d{3}-\d{4}$)" >


// now you have typed access to the regex groups and you can browse it via Intellisense
PhoneRegex().TypedMatch("425-123-2345").AreaCode.Value

// [fsi:val it : string = "425"]

// you can also get an option for simpler handling in case the rege doesn't match
match PhoneRegex().TryTypedMatch("425-123-2345") with
| Some m -> printfn "Phone number is %s" m.PhoneNumber.Value
| None -> printfn "Phone number unavailable"

(**

![alt text](img/RegexProvider.png "Intellisense for regular expressions")

Note that since version 1.0, generated methods are prefixed by `Typed` by default.
You can disable this behaviour using the parameter `noMethodPrefix`:
*)

type MultiplePhoneRegex = Regex< @"\b(?<AreaCode>\d{3})-(?<PhoneNumber>\d{3}-\d{4})\b", noMethodPrefix = true >

// now the generated types are just added as an overload of the existing method name on the `Regex` type
MultiplePhoneRegex().Matches("425-123-2345, 426-123-2346, 427-123-2347")
|> Seq.map (fun x -> x.AreaCode.Value)
|> List.ofSeq

// [fsi:val it : string list = ["425"; "426"; "427"]]

(**
To ease the conversion of matched groups to primitives types, the assembly provides
the FSharp.Text.RegexExtensions module. It contains extensions methods to convert matched groups
to `int`, `uint32`, `int64`, `uint64`, `int16`, `uint16`, `byte`, `sbyte`, 
`float`, `single`, `decimal`, `DateTime`, `DateTimeOffset`, `TimeSpan`, `bool` and `char`:
*)

open FSharp.Text.RegexExtensions

type TempRegex = Regex< @"^(?<Temperature>[\d\.]+)\s*°C$", noMethodPrefix = true >

// the simplest extension gets an option string depending on Success
TempRegex().Match("21.3°C").Temperature.TryValue
// [fsi:val it : string option = Some "21.3"]

// conversion to decimal in the happy case
TempRegex().Match("21.3°C").Temperature.AsDecimal
// [fsi:val it : decimal = 21.3M]

// When not sure whether the match occured or the format is always correct use TryAs...
// here it's successful
TempRegex().Match("21.3°C").Temperature.TryAsDecimal
// [fsi:val it : decimal option = Some 21.3M]

// here it returns None because it's not °C, so it doesn't match
TempRegex().Match("21.3°F").Temperature.TryAsDecimal
// [fsi:val it : decimal option = None]

// here it matches, but it is not a valid decimal
TempRegex().Match("21.3.5°F").Temperature.TryAsDecimal
// [fsi:val it : decimal option = None]

type DateRegex = Regex< @"^Date:\s*(?<Date>\d{4}-\d{2}-\d{2})$", noMethodPrefix = true >

// for dates, specify a format, especially for local or utc conversion
DateRegex().Match("Date: 2019-06-18").Date.AsDateTime(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
// [fsi:val it : System.DateTime = 18/06/2019 00:00:00]

(**

Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/FSharp.Text.RegexProvider/tree/master/docs/content
  [gh]: https://github.com/fsprojects/FSharp.Text.RegexProvider
  [issues]: https://github.com/fsprojects/FSharp.Text.RegexProvider/issues
  [readme]: https://github.com/fsprojects/FSharp.Text.RegexProvider/blob/master/README.md
  [license]: https://github.com/fsprojects/FSharp.Text.RegexProvider/blob/master/LICENSE.txt
*)
