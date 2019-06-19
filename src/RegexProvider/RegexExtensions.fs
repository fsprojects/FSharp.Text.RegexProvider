module FSharp.Text.RegexExtensions

open System
open System.Text.RegularExpressions
open System.Globalization

let inline private tryParseNumber (g:Group) style : ^t option =
    if g.Success then
        let mutable value = Unchecked.defaultof< ^t >
        if (^t : (static member TryParse: string * NumberStyles * CultureInfo * ^t byref -> bool ) (g.Value, style, CultureInfo.InvariantCulture,&value)) then
            Some value
        else
            None
    else
        None

let inline private tryParseDate (g:Group) style : ^t option =
    if g.Success then
        let mutable value = Unchecked.defaultof< ^t >
        if (^t : (static member TryParse: string *  CultureInfo * DateTimeStyles * ^t byref -> bool ) (g.Value, CultureInfo.InvariantCulture, style ,&value)) then
            Some value
        else
            None
    else
        None


type Group with
    member this.TryValue =
        if this.Success then Some this.Value else None
    member this.AsInt = int this.Value
    member this.AsUInt32 = uint32 this.Value
    member this.AsInt64 = int64 this.Value
    member this.AsUInt64 = uint64 this.Value
    member this.AsInt16 = int16 this.Value
    member this.AsUInt16 = uint16 this.Value
    member this.AsByte = byte this.Value
    member this.AsSByte = sbyte this.Value
    member this.AsDecimal = decimal this.Value
    member this.AsFloat = float this.Value
    member this.AsSingle = single this.Value
    member this.AsDateTime style = DateTime.Parse(this.Value, CultureInfo.InvariantCulture, style)
    member this.AsDateTimeOffset style = DateTimeOffset.Parse(this.Value, CultureInfo.InvariantCulture, style)
    member this.AsTimeSpan = TimeSpan.Parse(this.Value, CultureInfo.InvariantCulture)
    member this.AsBool = Boolean.Parse(this.Value)
    member this.AsChar = char this.Value

    member this.TryAsInt : int option = tryParseNumber this NumberStyles.Integer
    member this.TryAsUInt32 : uint32 option = tryParseNumber this NumberStyles.Integer
    member this.TryAsInt64 : int64 option = tryParseNumber this NumberStyles.Integer
    member this.TryAsUInt64 : uint64 option = tryParseNumber this NumberStyles.Integer
    member this.TryAsInt16 : int16 option = tryParseNumber this NumberStyles.Integer
    member this.TryAsUInt16 : uint16 option = tryParseNumber this NumberStyles.Integer
    member this.TryAsByte : byte option = tryParseNumber this NumberStyles.Integer
    member this.TryAsSByte : sbyte option= tryParseNumber this NumberStyles.Integer
    member this.TryAsDecimal : decimal option = tryParseNumber this NumberStyles.Number
    member this.TryAsFloat : float option = tryParseNumber this NumberStyles.Float 
    member this.TryAsSingle : single option = tryParseNumber this NumberStyles.Float
    member this.TryAsDateTime style : DateTime option = tryParseDate this style
    member this.TryAsDateTimeOffset style : DateTimeOffset option = tryParseDate this style
    member this.TryAsTimeSpan : TimeSpan option =
        if this.Success then
            match TimeSpan.TryParse(this.Value, CultureInfo.InvariantCulture) with
            | true, value -> Some value
            | false, _ -> None
        else
            None
    member this.TryAsBool : bool option =
        if this.Success then
            match Boolean.TryParse(this.Value) with
            | true, value -> Some value
            | false, _ -> None
        else
            None
    member this.TryAsChar : char option =
        if this.Success then
            match Char.TryParse(this.Value) with
            | true, value -> Some value
            | false, _ -> None
        else
            None

