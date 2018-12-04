namespace AdventOfCode2018.Tests

open System

open Xunit
open Xunit.Abstractions
open Swensen.Unquote

open AdventOfCode2018

type ``Day02 tests`` (output : ITestOutputHelper) =

    [<Fact>]
    let ``(Part1) From web page`` () =
        Day02.containsN 2 "abcdef" =! false
        Day02.containsN 3 "abcdef" =! false

        Day02.containsN 2 "bababc" =! true
        Day02.containsN 3 "bababc" =! true

        Day02.containsN 2 "abbcde" =! true
        Day02.containsN 3 "abbcde" =! false

        Day02.containsN 2 "abcccd" =! false
        Day02.containsN 3 "abcccd" =! true

        Day02.containsN 2 "aabcdd" =! true
        Day02.containsN 3 "aabcdd" =! false

        Day02.containsN 2 "abcdee" =! true
        Day02.containsN 3 "abcdee" =! false

        Day02.containsN 2 "ababab" =! false
        Day02.containsN 3 "ababab" =! true

        Day02.parseInput "abcdef, bababc, abbcde, abcccd, aabcdd, abcdee, ababab" |> Day02.checksum =! 12

    [<Fact>]
    let ``(Part2) From web page`` () =
        Day02.commonChars "abcde" "fghij" =! ""
        Day02.commonChars "abcde" "axcye" =! "ace"
        Day02.commonChars "fghij" "fguij" =! "fgij" 
        Day02.findTwoStingsWithCommonChars (Day02.parseInput "abcde, fghij, klmno, pqrst, fguij, axcye, wvxyz") 4 =! "fgij" 

