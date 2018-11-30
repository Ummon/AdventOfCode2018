module AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day01 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) My test`` () =
        1 =! 2
