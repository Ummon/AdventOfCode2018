module AdventOfCode2018.Day06

open System

type Coords = { X : int; Y : int }
    with
        member this.Distance (coords : Coords) : int =
            abs (coords.X - this.X) + abs (coords.Y - this.Y)

        static member Parse (str : string) =
            let coords = str.Split ','
            { X = int coords.[0]; Y = int coords.[1] }

let parseInput (str : string) : Coords array =
    str.Split ([| '\r'; '\n'; |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Coords.Parse

let getLargestArea (coords : Coords array) : int =
    let coordsX = coords |> Array.map (fun coords -> coords.X)
    let coordsY = coords |> Array.map (fun coords -> coords.Y)
    let minX, minY, maxX, maxY = coordsX |> Array.min, coordsY |> Array.min, coordsX |> Array.max, coordsY |> Array.max

    let areas = Array.zeroCreate coords.Length

    for x = minX to maxX do
        for y = minY to maxY do
            let pos = { X = x; Y = y }
            let mutable nearest = -1
            let mutable distance = Int32.MaxValue
            let mutable equalDistance = false

            for i = 0 to coords.Length - 1 do
                let distance' = pos.Distance coords.[i]
                if distance' = distance then
                    equalDistance <- true
                if distance' < distance then
                    nearest <- i
                    distance <- distance'
                    equalDistance <- false

            if not equalDistance then
                if x = minX || y = minY || x = maxX || y = maxY then
                    areas.[nearest] <- -1
                elif areas.[nearest] <> -1 then
                    areas.[nearest] <- areas.[nearest] + 1

    areas |> Array.max

let getAreaWithTotalDistanceLessThan (total : int) (coords : Coords array) : int =
    let coordsX = coords |> Array.map (fun coords -> coords.X)
    let coordsY = coords |> Array.map (fun coords -> coords.Y)
    let minX, minY, maxX, maxY = coordsX |> Array.min, coordsY |> Array.min, coordsX |> Array.max, coordsY |> Array.max

    let mutable area = 0

    for x = minX to maxX do
        for y = minY to maxY do
            let pos = { X = x; Y = y }
            let mutable totalDistance = 0
            for i = 0 to coords.Length - 1 do
                totalDistance <- totalDistance + pos.Distance coords.[i]
            if totalDistance < total then
                area <- area + 1

    area