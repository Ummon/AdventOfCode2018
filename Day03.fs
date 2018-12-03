module AdventOfCode2018.Day03

open System
open System.Collections.Generic

type Claim =
    {
        Id : int
        Left : int
        Top : int
        Width : int
        Height : int
    }
    with
        member this.Coordinates : (int * int) list =
            [        
                for x in this.Left .. this.Left + this.Width - 1 do
                    for y in this.Top .. this.Top + this.Height - 1 -> x, y
            ]

let parseInput (str : string) : Claim[] =
    str.Split ([| '\r'; '\n'; |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (
        fun claim ->
            let claim' = claim.Split ([| '#'; '@'; ','; ':'; 'x'; ' ' |], StringSplitOptions.RemoveEmptyEntries) |> Array.map int
            { Id = claim'.[0]; Left = claim'.[1]; Top = claim'.[2]; Width = claim'.[3]; Height = claim'.[4] }
    )

let overlappingSurface (claims : Claim seq) : int * int =
    let occupiedSpace = Dictionary<(int*int), int> ()
    for c in claims do
        for (x, y) in c.Coordinates do
            occupiedSpace.[(x, y)] <- occupiedSpace.GetValueOrDefault ((x, y), 0) + 1

    occupiedSpace.Values |> Seq.filter ((<) 1) |> Seq.length, // Total surface of overlapped claims.
    (claims |> Seq.find (fun c -> c.Coordinates |> List.forall (fun coord -> occupiedSpace.[coord] = 1))).Id // Id of the first not overlapping claim.
    