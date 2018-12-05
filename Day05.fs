module AdventOfCode2018.Day05

open System

let diffMajMin = int 'a' - int 'A'

let reduce (polymer : char list) : char list =
    List.foldBack (
        fun a result ->
            match result with
            | b :: rest when int a - int b |> abs = diffMajMin -> rest
            | _ -> a :: result
    ) polymer [ ]

let findShortestPolymer (polymer : char list) : char list =
    polymer
    |> List.map Char.ToLower
    |> List.distinct
    |> List.map (fun unit -> polymer |> List.filter (fun c -> Char.ToLower c <> unit) |> reduce)
    |> List.minBy List.length
