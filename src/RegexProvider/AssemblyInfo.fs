namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyProductAttribute("FSharp.Text.RegexProvider")>]
[<assembly: AssemblyDescriptionAttribute("A type provider for regular expressions.")>]
[<assembly: AssemblyVersionAttribute("1.0.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0.0"
