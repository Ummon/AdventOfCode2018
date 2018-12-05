namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day05 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        let input = List.ofSeq "dabAcCaCBAcCcaDA"
        Day05.reduce input =! List.ofSeq "dabCBAcaDA"

    [<Fact>]
    let ``(Part2) From web page`` () =
        let input = List.ofSeq "dabAcCaCBAcCcaDA"
        Day05.findShortestPolymer input =! List.ofSeq "daDA"

