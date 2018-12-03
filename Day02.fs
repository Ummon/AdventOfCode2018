module AdventOfCode2018.Day02

open System

let parseInput (str : string) : string[] =
    str.Split ([| '\r'; '\n'; ','; ' ' |], StringSplitOptions.RemoveEmptyEntries)

let containsN (n : int) (id : string) : bool =    
    id |> Seq.map (fun c -> id |> Seq.filter ((=) c) |> Seq.length) |> Seq.contains n

let checksum (ids : string[]) : int =
    let nbIds (n : int) = ids |> Seq.filter (containsN n) |> Seq.length
    nbIds 2 * nbIds 3

let commonChars (a : string) (b : string) : string =
    Seq.zip a b |> Seq.choose (fun (c1, c2) -> if c1 = c2 then Some c1 else None) |> String.Concat

let findTwoStingsWithCommonChars (l : string array) (n : int) : string =    
    let rec find i =
        match            
            (l.[i..] |> Array.tryPick (
                fun str -> 
                    let common = commonChars l.[i] str
                    if common.Length = n then Some common else None
            )) with
        | Some found -> found
        | None -> find (i + 1)
    find 0
