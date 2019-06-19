namespace FSharp.Text.RegexProvider

open ProviderImplementation.ProvidedTypes
open FSharp.Text.RegexProvider.Helper
open System
open System.IO
open System.Text.RegularExpressions
open Microsoft.FSharp.Core.CompilerServices

module internal TypedRegex =
    let typedRegex() = 
        let regexType = erasedType<Regex> thisAssembly rootNamespace "Regex" false
        regexType.DefineStaticParameters(
            parameters =
                [
                    ProvidedStaticParameter("pattern", typeof<string>)
                    ProvidedStaticParameter("noMethodPrefix", typeof<bool>, false)
                ], 
            instantiationFunction = (fun typeName parameterValues ->
                match parameterValues with 
                | [| :? string as pattern; :? bool as noMethodPrefix |] ->
                    let typeSet = createTypeSet()

                    let getMethodName baseName =
                        if noMethodPrefix then baseName
                        else sprintf "Typed%s" baseName

                    let matchType = runtimeType<Match>"MatchType" true typeSet

                    for group in Regex(pattern).GetGroupNames() do
                        let property = 
                            ProvidedProperty(
                                propertyName = (if group <> "0" then group else "CompleteMatch"),
                                propertyType = typeof<Group>,
                                getterCode = (fun args -> <@@ (%%args.[0]:Match).Groups.[group] @@>))
                        property.AddXmlDoc(sprintf @"Gets the ""%s"" group from this match" group)
                        matchType.AddMember property

                    let matchMethod =
                        ProvidedMethod(
                            methodName = getMethodName "NextMatch",
                            parameters = [],
                            returnType = matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Match).NextMatch() @@>))
                    matchMethod.AddXmlDoc "Searches the specified input string for the next occurrence of this regular expression."

                    matchType.AddMember matchMethod
                    

                    let regexType = erasedType<Regex> thisAssembly rootNamespace typeName true
                    regexType.AddXmlDoc "A strongly typed interface to the regular expression '%s'"

                    regexType.AddMember matchType

                    let isMatchMethod =
                        ProvidedMethod(
                            methodName = getMethodName "IsMatch",
                            parameters = [ProvidedParameter("input", typeof<string>)],
                            returnType = typeof<bool>,
                            invokeCode = (fun args -> <@@ Regex.IsMatch(%%args.[0], pattern) @@>),
                            isStatic = true)
                    isMatchMethod.AddXmlDoc "Indicates whether the regular expression finds a match in the specified input string"

                    regexType.AddMember isMatchMethod

                    let matchMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)],
                            returnType = matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Match(%%args.[1]) @@>))
                    matchMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression"

                    regexType.AddMember matchMethod
                    
                    let matchStartAtMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("startat", typeof<int>)],
                            returnType = matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Match(%%args.[1], %%args.[2]) @@>))
                    matchStartAtMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression, beginning at the specified starting position."

                    regexType.AddMember matchStartAtMethod

                    let matchBeginningLengthMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("beginning", typeof<int>)
                                          ProvidedParameter("length",typeof<int>)],
                            returnType = matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Match(%%args.[1], %%args.[2], %%args.[3] ) @@>))
                    matchBeginningLengthMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression, beginning at the specified starting position and searching only the specified number of characters."

                    regexType.AddMember matchBeginningLengthMethod

                    let tryMatchMethod =
                        ProvidedMethod(
                            methodName = "Try" + getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)],
                            returnType = optionType matchType,
                            invokeCode = (fun args -> 
                                <@@ let m = (%%args.[0]:Regex).Match(%%args.[1])
                                    if m.Success then
                                        Some m
                                    else
                                        None @@>))
                    tryMatchMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression."

                    regexType.AddMember tryMatchMethod

                    let tryMatchStartAtMethod =
                        ProvidedMethod(
                            methodName = "Try" + getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("startat", typeof<int>)],
                            returnType = optionType matchType,
                            invokeCode = (fun args -> 
                                <@@ let m = (%%args.[0]:Regex).Match(%%args.[1], %%args.[2])
                                    if m.Success then
                                        Some m
                                    else
                                        None @@>))
                    tryMatchStartAtMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression, beginning at the specified starting position."

                    regexType.AddMember tryMatchStartAtMethod

                    let tryMatchBeginningLengthMethod =
                        ProvidedMethod(
                            methodName = "Try" + getMethodName "Match",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("beginning", typeof<int>)
                                          ProvidedParameter("length", typeof<int>)],
                            returnType = optionType matchType,
                            invokeCode = (fun args -> 
                                <@@ let m = (%%args.[0]:Regex).Match(%%args.[1], %%args.[2], %%args.[3])
                                    if m.Success then
                                        Some m
                                    else
                                        None @@>))
                    tryMatchBeginningLengthMethod.AddXmlDoc "Searches the specified input string for the first occurrence of this regular expression, beginning at the specified starting position and searching only the specified number of characters."

                    regexType.AddMember tryMatchBeginningLengthMethod

                    let matchesMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Matches",
                            parameters = [ProvidedParameter("input", typeof<string>)],
                            returnType = seqType matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Matches(%%args.[1]) |> Seq.cast<Match> @@>))
                    matchesMethod.AddXmlDoc "Searches the specified input string for all occurrences of this regular expression."

                    regexType.AddMember matchesMethod

                    let matchesStartAtMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Matches",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("startat", typeof<int>)],
                            returnType = seqType matchType,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Matches(%%args.[1], %%args.[2]) |> Seq.cast<Match> @@>))
                    matchesStartAtMethod.AddXmlDoc "Searches the specified input string for all occurrences of this regular expression, beginning at the specified starting position in the string."

                    regexType.AddMember matchesStartAtMethod
                    
                    let replaceMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Replace",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("evaluator", funType matchType typeof<string>)],
                            returnType = typeof<string>,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Replace(%%args.[1], MatchEvaluator(%%args.[2] )) @@>))
                    replaceMethod.AddXmlDoc "In a specified input string, replaces all strings that match a specified regular expression with a string returned by an evaluator function."
                    
                    regexType.AddMember replaceMethod
                
                    let replaceCountMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Replace",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("evaluator", funType matchType typeof<string>)
                                          ProvidedParameter("count", typeof<int>)],
                            returnType = typeof<string>,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Replace(%%args.[1], MatchEvaluator(%%args.[2] ), %%args.[3]) @@>))
                    replaceCountMethod.AddXmlDoc "In a specified input string, replaces a specified maximum number of strings that match a specified regular expression with a string returned by an evaluator function."
                    
                    regexType.AddMember replaceCountMethod

                    let replaceCountStartAtMethod =
                        ProvidedMethod(
                            methodName = getMethodName "Replace",
                            parameters = [ProvidedParameter("input", typeof<string>)
                                          ProvidedParameter("evaluator", funType matchType typeof<string>)
                                          ProvidedParameter("count", typeof<int>)
                                          ProvidedParameter("startat", typeof<int>)],
                            returnType = typeof<string>,
                            invokeCode = (fun args -> <@@ (%%args.[0]:Regex).Replace(%%args.[1], MatchEvaluator(%%args.[2] ),%%args.[3], %%args.[4]) @@>))
                    replaceCountStartAtMethod.AddXmlDoc "In a specified input substring, replaces a specified maximum number of strings that match a specified regular expression with a string returned by an evaluator function."
                    
                    regexType.AddMember replaceCountStartAtMethod

                    let ctor = 
                        ProvidedConstructor(
                            parameters = [], 
                            invokeCode = (fun args -> <@@ Regex(pattern) @@>))

                    ctor.AddXmlDoc "Initializes a regular expression instance"
                    regexType.AddMember ctor

                    let ctor =
                        ProvidedConstructor(
                            parameters = [ProvidedParameter("options", typeof<RegexOptions>)],
                            invokeCode = (fun args -> <@@ Regex(pattern, %%args.[0]) @@>))
                    ctor.AddXmlDoc "Initializes a regular expression instance, with options that modify the pattern."                
                    regexType.AddMember ctor

                    let ctor =
                        ProvidedConstructor(
                            parameters = [ProvidedParameter("options", typeof<RegexOptions>)
                                          ProvidedParameter("matchTimeout", typeof<TimeSpan>)],
                            invokeCode = (fun args -> <@@ Regex(pattern, %%args.[0], %%args.[1]) @@>))
                    ctor.AddXmlDoc "Initializes a regular expression instance, with options that modify the pattern and a value that specifies how long a pattern matching method should attempt a match before it times out."                
                    regexType.AddMember ctor

                    regexType
                | _ -> failwith "unexpected parameter values"))
        regexType

[<TypeProvider>]
type public RegexProvider(cfg:TypeProviderConfig) =
    inherit TypeProviderForNamespaces(cfg, rootNamespace, [TypedRegex.typedRegex()])


[<TypeProviderAssembly>]
do ()
