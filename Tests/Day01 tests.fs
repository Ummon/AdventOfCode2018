namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day01 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day01.parseInput "+1, +1, +1" |> Day01.finalFrequency =! 3
        Day01.parseInput "+1, +1, -2" |> Day01.finalFrequency =! 0
        Day01.parseInput "-1, -2, -3" |> Day01.finalFrequency =! -6
        
    [<Fact>]
    let ``(Part2) From web page`` () =
        Day01.parseInput "+1, -1" |> Day01.firstDuplicate =! 0
        Day01.parseInput "+3, +3, +4, -2, -4" |> Day01.firstDuplicate =! 10
        Day01.parseInput "-6, +3, +8, +5, -6" |> Day01.firstDuplicate =! 5
        Day01.parseInput "+7, +7, -2, -7, -4" |> Day01.firstDuplicate =! 14

