module AdventOfCode2018.Main

open System
open System.IO

let day01 () =
    let changes = File.ReadAllText "Data/day01.input" |> Day01.parseInput
    sprintf "part1 = %A, part2 = %A" (Day01.finalFrequency changes) (Day01.firstDuplicate changes)

let days : (unit -> string) array =
    [|
        day01
    |]

let doDay (n : int) =
    if n < 1 then
        ArgumentException "day number must be greater or equal to 1" |> raise
    elif n > days.Length then
        NotImplementedException (sprintf "no implementation for day %i" n) |> raise
    else
        let sw = Diagnostics.Stopwatch ()
        sw.Start ()
        let result = days.[n - 1] ()
        printfn "Result of day %i: %s (time : %i ms)" n result sw.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
    printfn "https://adventofcode.com/2018"

    if argv.Length > 0 then
        doDay (int argv.[0])
    else
        for d = 1 to days.Length do
            doDay d

    Console.Read () |> ignore
    0
