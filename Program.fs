module AdventOfCode2018.Main

open System
open System.IO

let day01 () =
    let changes = File.ReadAllText "Data/day01.input" |> Day01.parseInput
    sprintf "part1 = %A, part2 = %A" (Day01.finalFrequency changes) (Day01.firstDuplicate changes)

let day02 () =
    let ids = File.ReadAllText "Data/day02.input" |> Day02.parseInput
    let idLength = ids.[0].Length
    sprintf "part1 = %A, part2 = %A" (Day02.checksum ids) (Day02.findTwoStingsWithCommonChars ids (idLength - 1))

let day03 () =
    let claims = File.ReadAllText "Data/day03.input" |> Day03.parseInput
    let surface, claimId = Day03.overlappingSurface claims
    sprintf "part1 = %A, part2 = %A" surface claimId

let day04 () =
    let (sleepestGuardId, sleepestTime), (sleepestGuardIdSameTime, sleepestTimeSameTime) = File.ReadAllText "Data/day04.input" |> Day04.getSleepestGuard
    sprintf "part1 = %A, part2 = %A" (sleepestGuardId * sleepestTime) (sleepestGuardIdSameTime * sleepestTimeSameTime)

let day05 () =
    let reduced = (File.ReadAllText "Data/day05.input").Trim () |> List.ofSeq |> Day05.reduce
    sprintf "part1 = %A, part2 = %A" reduced.Length (Day05.findShortestPolymer reduced).Length

let day06 () =
    let coords = File.ReadAllText "Data/day06.input" |> Day06.parseInput
    sprintf "part1 = %A, part2 = %A" (Day06.getLargestArea coords) (Day06.getAreaWithTotalDistanceLessThan 10000 coords)

let day07 () =
    let constraints = File.ReadAllText "Data/day07.input" |> Day07.parseInput
    sprintf "part1 = %A, part2 =" (Day07.order constraints |> String.Concat)

let days : Map<int, unit -> string> =
    [
        1, day01
        2, day02
        3, day03
        4, day04
        5, day05
        6, day06
        7, day07
    ] |> Map.ofList

let doDay (n : int) =
    if n < 1 then
        ArgumentException "day number must be greater or equal to 1" |> raise

    else
        match Map.tryFind n days with
        | Some day ->
            let sw = Diagnostics.Stopwatch ()
            sw.Start ()
            let result = day ()
            printfn "Result of day %i: %s (time : %i ms)" n result sw.ElapsedMilliseconds

        | None ->
            NotImplementedException (sprintf "no implementation for day %i" n) |> raise

[<EntryPoint>]
let main argv =
    printfn "https://adventofcode.com/2018"

    if argv.Length > 0 then
        doDay (int argv.[0])
    else
        for day in days do
            doDay day.Key
    0
