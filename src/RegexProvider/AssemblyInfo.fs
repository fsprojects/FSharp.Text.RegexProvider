namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyProductAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyDescriptionAttribute("A type provider for regular expressions.")>]
[<assembly: AssemblyVersionAttribute("0.0.7")>]
[<assembly: AssemblyFileVersionAttribute("0.0.7")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.7"
