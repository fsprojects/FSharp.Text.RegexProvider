namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyProductAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyDescriptionAttribute("A type provider for regular expressions.")>]
[<assembly: AssemblyVersionAttribute("0.0.6")>]
[<assembly: AssemblyFileVersionAttribute("0.0.6")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.6"
