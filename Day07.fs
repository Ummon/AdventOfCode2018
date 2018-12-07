module AdventOfCode2018.Day07

open System

type Constraint = char * char

let parseInput (str : string) : Constraint array =
    str.Split ([| '\r'; '\n'; |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (
        fun line ->
            let trimmedLine = line.Trim  ()
            trimmedLine.[5], trimmedLine.[36]
    )

let order (constraints : Constraint array) : char array =
    let constraints = constraints |> Array.sortBy fst

    let rec loop (constraints : Constraint array) : char list =
        match constraints with
        | [| (a, b) |] -> [ a; b ]
        | _ ->
            let next = constraints |> Array.pick (fun (a, _) -> if constraints |> Array.forall (fun (_, b) -> a <> b) then Some a else None)
            let rest = constraints |> Array.filter (fst >> ((<>) next))
            next :: (loop rest)

    loop constraints |> Array.ofList