module AdventOfCode2018.Day02

open System

let parseInput (str : string) : string[] =
    str.Split ([| "\r\n"; "\r"; "\n" |], StringSplitOptions.RemoveEmptyEntries)

let containsN (id : string) : bool =
    false

