namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day06 tests`` (output : ITestOutputHelper) =
    let input =
        """1, 1
           1, 6
           8, 3
           3, 4
           5, 5
           8, 9"""

    [<Fact>]
    let ``(Part1) From web page`` () =
        let coords = Day06.parseInput input
        Day06.getLargestArea coords =! 17

    [<Fact>]
    let ``(Part2) From web page`` () =
        let coords = Day06.parseInput input
        Day06.getAreaWithTotalDistanceLessThan 32 coords =! 16

