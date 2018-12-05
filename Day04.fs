module AdventOfCode2018.Day04

open System
open System.Collections.Generic

let getSleepestGuard (str : string) : (int * int) * (int * int) =
    let shifts : int list array = Array.create 60 []

    let lines =
        str.Split ([| '\r'; '\n'; |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.choose (
            fun line ->
                let trimmed = line.Trim ()
                if trimmed = "" then None else Some (DateTime.Parse (trimmed.Substring (1, 16)), trimmed)
        )
        |> Array.sortBy fst

    let mutable guardId = 0
    let minutesAsleep = Dictionary<int, int> ()

    let addShift (date1 : DateTime) (date2 : DateTime) =
        let min1 = if date1.Hour > 0 then 0 else date1.Minute
        let min2 = if date2.Hour > 0 then 60 else date2.Minute

        minutesAsleep.[guardId] <- minutesAsleep.GetValueOrDefault (guardId, 0) + min2 - min1

        for m = min1 to min2 - 1 do
            shifts.[m] <- guardId :: shifts.[m]

    for i = 0 to lines.Length - 1 do
        let dateTime, line = lines.[i]
        match line.IndexOf '#' with
        | i when i <> -1 -> guardId <- line.Substring (i + 1, line.IndexOf (' ', i) - i - 1) |> int
        | _ ->
            if line.Contains "wakes up" then
                addShift (fst lines.[i-1]) dateTime

    let sleepestGuardId, _  = minutesAsleep |> Seq.fold (fun (id, max) guard -> if guard.Value > max then guard.Key, guard.Value else id, max) (0, 0)

    let mutable sleepestTime = 0
    let mutable asleepCountMax = 0

    let mutable sleepestTimeSameTime = 0
    let mutable asleepCountMaxSameTime = 0
    let mutable sleepestGuardIdSameTime = 0

    for i = 0 to shifts.Length - 1 do
        let asleepCount = shifts.[i] |> List.where ((=) sleepestGuardId) |> List.length
        if asleepCount > asleepCountMax then
            sleepestTime <- i
            asleepCountMax <- asleepCount

        match shifts.[i] |> List.groupBy id |> List.map (fun (id, ids) -> id, List.length ids) |> List.sortByDescending snd |> List.tryHead with
        | Some (id, nb) ->
            if nb > asleepCountMaxSameTime then
                asleepCountMaxSameTime <- nb
                sleepestTimeSameTime <- i
                sleepestGuardIdSameTime <- id

        | None -> ()

    (sleepestGuardId, sleepestTime), (sleepestGuardIdSameTime, sleepestTimeSameTime)
