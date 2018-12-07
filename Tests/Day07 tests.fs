namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day07 tests`` (output : ITestOutputHelper) =
    let input =
        """Step C must be finished before step A can begin.
           Step C must be finished before step F can begin.
           Step A must be finished before step B can begin.
           Step A must be finished before step D can begin.
           Step B must be finished before step E can begin.
           Step D must be finished before step E can begin.
           Step F must be finished before step E can begin."""

    [<Fact>]
    let ``(Part1) From web page`` () =
        let constrains = Day07.parseInput input
        Day07.order constrains |> String.Concat =! "CABDFE"

    [<Fact>]
    let ``(Part2) From web page`` () =
        ()

