module FSharp.Text.RegexProvider.Tests.RegexExtensionsTests

open System
open NUnit.Framework
open FSharp.Text.RegexProvider
open FSharp.Text.RegexExtensions
open System.Globalization
open FsUnit


type PhoneRegex = Regex< @"^(\(\+(?<Prefix>\d+)\))?\s*(?<PhoneNumber>[\d-]+$)", noMethodPrefix = true >
[<Test>] 
let ``Group extension TryValue``() =      
    PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryValue
    |> shouldEqual (Some "33")

[<Test>] 
let ``Group extension TryValue when not available``() =      
    PhoneRegex().Match("425-123-2345").Prefix.TryValue
    |> shouldEqual None

module TestInt32 = 
    [<Test>] 
    let ``Group extension AsInt``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsInt
        |> shouldEqual 33


    [<Test>] 
    let ``Group extension TryAsInt when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsInt
        |> shouldEqual (Some 33)

    [<Test>] 
    let ``Group extension TryAsInt when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsInt
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsInt when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsInt
        |> shouldEqual None

module TestUInt32 =
    [<Test>] 
    let ``Group extension AsUInt32``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsUInt32
        |> shouldEqual 33u


    [<Test>] 
    let ``Group extension TryAsUInt32 when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsUInt32
        |> shouldEqual (Some 33u)

    [<Test>] 
    let ``Group extension TryAsUInt32 when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsUInt32
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsUInt32 when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsUInt32
        |> shouldEqual None


module TestInt64 = 
    [<Test>] 
    let ``Group extension AsInt64``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsInt64
        |> shouldEqual 33L


    [<Test>] 
    let ``Group extension TryAsInt64 when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsInt64
        |> shouldEqual (Some 33L)

    [<Test>] 
    let ``Group extension TryAsInt64 when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsInt64
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsInt64 when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsInt64
        |> shouldEqual None

module TestUInt64 =
    [<Test>] 
    let ``Group extension AsUInt64``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsUInt64
        |> shouldEqual 33UL


    [<Test>] 
    let ``Group extension TryAsUInt64 when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsUInt64
        |> shouldEqual (Some 33UL)

    [<Test>] 
    let ``Group extension TryAsUInt64 when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsUInt64
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsUInt64 when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsUInt64
        |> shouldEqual None


module TestInt16 = 
    [<Test>] 
    let ``Group extension AsInt16``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsInt16
        |> shouldEqual 33s


    [<Test>] 
    let ``Group extension TryAsInt16 when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsInt16
        |> shouldEqual (Some 33s)

    [<Test>] 
    let ``Group extension TryAsInt16 when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsInt16
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsInt16 when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsInt16
        |> shouldEqual None

module TestUInt16 =
    [<Test>] 
    let ``Group extension AsUInt16``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsUInt16
        |> shouldEqual 33us


    [<Test>] 
    let ``Group extension TryAsUInt16 when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsUInt16
        |> shouldEqual (Some 33us)

    [<Test>] 
    let ``Group extension TryAsUInt16 when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsUInt16
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsUInt16 when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsUInt16
        |> shouldEqual None


module TestByte = 
    [<Test>] 
    let ``Group extension AsByte``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsByte
        |> shouldEqual 33uy


    [<Test>] 
    let ``Group extension TryAsByte when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsByte
        |> shouldEqual (Some 33uy)

    [<Test>] 
    let ``Group extension TryAsByte when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsByte
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsByte when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsByte
        |> shouldEqual None

module TestSByte =
    [<Test>] 
    let ``Group extension AsSByte``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.AsSByte
        |> shouldEqual 33y


    [<Test>] 
    let ``Group extension TryAsSByte when available``() =      
        PhoneRegex().Match("(+33) 425-123-2345").Prefix.TryAsSByte
        |> shouldEqual (Some 33y)

    [<Test>] 
    let ``Group extension TryAsSByte when not available``() =      
        PhoneRegex().Match("425-123-2345").Prefix.TryAsSByte
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsSByte when not valid``() =      
        PhoneRegex().Match("425-123-2345").PhoneNumber.TryAsSByte
        |> shouldEqual None


type TempRegex = Regex< @"^(?<Temperature>[\d\.*]+)\s*°C$", noMethodPrefix = true >
module TestDecimal =
    [<Test>] 
    let ``Group extension AsDecimal``() =      
        TempRegex().Match("21.3°C").Temperature.AsDecimal
        |> shouldEqual 21.3m


    [<Test>] 
    let ``Group extension TryAsDecimal when available``() =      
        TempRegex().Match("21.3°C").Temperature.TryAsDecimal
        |> shouldEqual (Some 21.3m)

    [<Test>] 
    let ``Group extension TryAsDecimal when not available``() =      
        TempRegex().Match("°C").Temperature.TryAsDecimal
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsDecimal when not valid``() =      
        TempRegex().Match("21.3.5°C").Temperature.TryAsDecimal
        |> shouldEqual None

module TestFloat =
    [<Test>] 
    let ``Group extension AsFloat``() =      
        TempRegex().Match("21.3°C").Temperature.AsFloat
        |> shouldEqual 21.3


    [<Test>] 
    let ``Group extension TryAsFloat when available``() =      
        TempRegex().Match("21.3°C").Temperature.TryAsFloat
        |> shouldEqual (Some 21.3)

    [<Test>] 
    let ``Group extension TryAsFloat when not available``() =      
        TempRegex().Match("°C").Temperature.TryAsFloat
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsFloat when not valid``() =      
        TempRegex().Match("21*3°C").Temperature.TryAsFloat
        |> shouldEqual None

module TestSingle =
    [<Test>] 
    let ``Group extension AsSingle``() =      
        TempRegex().Match("21.3°C").Temperature.AsSingle
        |> shouldEqual 21.3f


    [<Test>] 
    let ``Group extension TryAsSingle when available``() =      
        TempRegex().Match("21.3°C").Temperature.TryAsSingle
        |> shouldEqual (Some 21.3f)

    [<Test>] 
    let ``Group extension TryAsSingle when not available``() =      
        TempRegex().Match("°C").Temperature.TryAsSingle
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsSingle when not valid``() =      
        TempRegex().Match("21*3°C").Temperature.TryAsSingle
        |> shouldEqual None

type DateRegex = Regex< @"^Date:\s*(?<Date>\d{4}-\d{2}-\d{2})$", noMethodPrefix = true >
module TestDateTime =
    [<Test>] 
    let ``Group extension AsDateTime``() =      
        DateRegex().Match("Date: 2019-06-18").Date.AsDateTime(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual (DateTime(2019,6,18, 0,0,0,DateTimeKind.Utc))


    [<Test>] 
    let ``Group extension AsDateTime when available``() =      
        DateRegex().Match("Date: 2019-06-18").Date.TryAsDateTime(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual (Some (DateTime(2019,6,18, 0,0,0,DateTimeKind.Utc)))

    [<Test>] 
    let ``Group extension AsDateTime when not available``() =      
        DateRegex().Match("DateTime: 2019-06-18").Date.TryAsDateTime(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual None


    [<Test>] 
    let ``Group extension AsDateTime when not valid``() =      
        DateRegex().Match("DateTime: 2019-99-18").Date.TryAsDateTime(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual None

module TestDateTimeOffset =
    [<Test>] 
    let ``Group extension AsDateTimeOffset``() =      
        DateRegex().Match("Date: 2019-06-18").Date.AsDateTimeOffset(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual (DateTimeOffset(2019,6,18, 0,0,0,TimeSpan.Zero))


    [<Test>] 
    let ``Group extension TryAsDateTimeOffset when available``() =      
        DateRegex().Match("Date: 2019-06-18").Date.TryAsDateTimeOffset(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual (Some (DateTimeOffset(2019,6,18, 0,0,0,TimeSpan.Zero)))

    [<Test>] 
    let ``Group extension TryAsDateTimeOffset when not available``() =      
        DateRegex().Match("DateTime: 2019-06-18").Date.TryAsDateTimeOffset(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsDateTimeOffset when not valid``() =      
        DateRegex().Match("DateTime: 2019-99-18").Date.TryAsDateTimeOffset(DateTimeStyles.AssumeUniversal|||DateTimeStyles.AdjustToUniversal)
        |> shouldEqual None

type TimeSpanRegex = Regex< @"^TimeSpan:\s*(?<TimeSpan>\d{2}:\d{2}:\d{2})$", noMethodPrefix = true >
module TestTimeSpan =
    [<Test>] 
    let ``Group extension AsTimeSpan``() =      
        TimeSpanRegex().Match("TimeSpan: 13:39:24").TimeSpan.AsTimeSpan
        |> shouldEqual (TimeSpan(13,39,24))


    [<Test>] 
    let ``Group extension TryAsTimeSpan when available``() =      
        TimeSpanRegex().Match("TimeSpan: 13:39:24").TimeSpan.TryAsTimeSpan
        |> shouldEqual (Some (TimeSpan(13,39,24)))

    [<Test>] 
    let ``Group extension TryAsTimeSpan when not available``() =      
        TimeSpanRegex().Match("Time: 13:39:24").TimeSpan.TryAsTimeSpan
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsTimeSpan when not valid``() =      
        TimeSpanRegex().Match("TimeSpan: 13:70:24").TimeSpan.TryAsTimeSpan
        |> shouldEqual None

type BoolRegex = Regex< @"^Bool:\s*(?<Bool>\w{4,5})$", noMethodPrefix = true >
module TestBool =
    [<Test>] 
    let ``Group extension AsBool``() =      
        BoolRegex().Match("Bool: true").Bool.AsBool
        |> shouldEqual true


    [<Test>] 
    let ``Group extension TryAsBool when available``() =      
        BoolRegex().Match("Bool: false").Bool.TryAsBool
        |> shouldEqual (Some false)

    [<Test>] 
    let ``Group extension TryAsBool when not available``() =      
        BoolRegex().Match("Value: true").Bool.TryAsBool
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsBool when not valid``() =      
        BoolRegex().Match("Bool: right").Bool.TryAsBool
        |> shouldEqual None

type CharRegex = Regex< @"^Char:\s*(?<Char>\w{1,2})$", noMethodPrefix = true >
module TestChar =
    [<Test>] 
    let ``Group extension AsChar``() =      
        CharRegex().Match("Char: X").Char.AsChar
        |> shouldEqual 'X'


    [<Test>] 
    let ``Group extension TryAsBool when available``() =      
        CharRegex().Match("Char: X").Char.TryAsChar
        |> shouldEqual (Some 'X')

    [<Test>] 
    let ``Group extension TryAsBool when not available``() =      
        CharRegex().Match("Value: true").Char.TryAsChar
        |> shouldEqual None


    [<Test>] 
    let ``Group extension TryAsBool when not valid``() =      
        CharRegex().Match("Char: XY").Char.TryAsChar
        |> shouldEqual None
