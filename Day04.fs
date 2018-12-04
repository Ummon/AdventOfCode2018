module AdventOfCode2018.Day04

open System

let parseInput (str : string) : string =
    let shifts : int list array = Array.create 60 []

    let addShift (id : int) (date1 : DateTime) (date2 : DateTime) =

        let min1 = if date1.Hour > 0 then 0 else date1.Minute
        let min2 = if date2.Hour > 0 then 59 else date2.Minute

        for m = min1 to min2 - 1 do
            shifts.[m] <- id :: shifts.[m]

    let lines =
        str.Split ([| '\r'; '\n'; |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.choose (
            fun line ->
                let trimmed = line.Trim ()
                if trimmed = "" then None else Some (DateTime.Parse (trimmed.Substring (1, 16)), trimmed)
        )
        |> Array.sortBy fst
        (*
        |> Array.fold (
            fun id (dateTime, line) ->
                match line.IndexOf '#' with
                | i when i <> -1 -> line.Substring (i + 1, line.IndexOf (' ', i) - i - 1) |> int
                | _ ->
        ) 0*)

    let mutable id = 0

    for i = 0 to lines.Length - 1 do
        let dateTime, line = lines.[i]
        match line.IndexOf '#' with
        | i when i <> -1 -> id <- line.Substring (i + 1, line.IndexOf (' ', i) - i - 1) |> int
        | _ ->
            if line.Contains "wakes up" then
                addShift id (fst lines.[i-1]) dateTime

    sprintf "%A" shifts







    //Map<int, int>.


    //