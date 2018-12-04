namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day03 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input = 
            """#1 @ 1,3: 4x4
               #2 @ 3,1: 4x4
               #3 @ 5,5: 2x2"""
        let claims = Day03.parseInput input
        Day03.overlappingSurface claims |> fst =! 4

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input = 
            """#1 @ 1,3: 4x4
               #2 @ 3,1: 4x4
               #3 @ 5,5: 2x2"""
        let claims = Day03.parseInput input
        Day03.overlappingSurface claims |> snd =! 3

