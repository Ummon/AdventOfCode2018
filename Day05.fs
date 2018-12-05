module AdventOfCode2018.Day05

open System

let diffMajMin = int 'A' - int 'a'

let reduce (polymer : string) : string =
    Seq.foldBack (
        fun a result ->
            match result with
            | b :: rest when int a - int b |> abs = diffMajMin -> rest
            | _ -> a :: result
    ) polymer [ ]
    |> Array.ofList
    |> String.Concat

let findShortestPolymer (polymer : string) : string =
    polymer.ToLower()
    |> Seq.distinct
    |> Seq.map (fun unit -> polymer.Replace(string unit, "", StringComparison.InvariantCultureIgnoreCase) |> reduce)
    |> Seq.minBy String.length
