module AdventOfCode2018.Day01

open System

let parseInput (str : string) : int[] =
    str.Split ([| "\r\n"; "\r"; "\n" |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int

let finalFrequency : seq<int> -> int =
    Seq.sum

let firstDuplicate (changes : seq<int>) : int =
    let repeatedChanges = seq { while true do yield! changes }
    Seq.scan (
        fun (_, sum, frequencies) change ->
            let sum' = sum + change
            if Set.contains sum' frequencies then
                (true, sum', frequencies)
            else
                (false, sum', Set.add sum' frequencies)

    ) (false, 0, Set.empty) repeatedChanges
    |> Seq.pick (fun (duplicate, sum, _) -> if duplicate then Some sum else None)
