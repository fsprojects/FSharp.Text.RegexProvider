namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("RegexProvider")>]
[<assembly: AssemblyProductAttribute("RegexProvider")>]
[<assembly: AssemblyDescriptionAttribute("A type provider for regular expressions.")>]
[<assembly: AssemblyVersionAttribute("0.0.2")>]
[<assembly: AssemblyFileVersionAttribute("0.0.2")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.2"
