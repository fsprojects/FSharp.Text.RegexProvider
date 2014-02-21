(*** hide ***)
#I "../../bin"

(**
RegexProvider
===========================

The RegexProvider project contains a type providers for regular expressions.

* [CommonFolders](CommonFolders.html)

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The library can be <a href="https://nuget.org/packages/RegexProvider">installed from NuGet</a>:
      <pre>PM> Install-Package RegexProvider</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

Example
-------

This example demonstrates the use of the type provider:

*)
// reference the type provider dll
#r "RegexProvider.dll"
open FSharp.RegexProvider

// Let the type provider do it's work
type PhoneRegex = Regex< @"(?<AreaCode>^\d{3})-(?<PhoneNumber>\d{3}-\d{4}$)">


// now you have typed access to the regex groups and you can browse it via Intellisense
PhoneRegex().Match("425-123-2345").AreaCode.Value

// [fsi:val it : string = "425"]

(**

![alt text](img/RegexProvider.png "Intellisense for regular expressions")

Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/RegexProvider/tree/master/docs/content
  [gh]: https://github.com/fsprojects/RegexProvider
  [issues]: https://github.com/fsprojects/RegexProvider/issues
  [readme]: https://github.com/fsprojects/RegexProvider/blob/master/README.md
  [license]: https://github.com/fsprojects/RegexProvider/blob/master/LICENSE.txt
*)
