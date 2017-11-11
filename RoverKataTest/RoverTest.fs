module RoverTest

open Xunit
open FsCheck.Xunit
open Rover

[<Fact>]
let test() = ()

[<Property>]
let ``Three rights make a left``(rover:Rover) =
    rover |> turnRight |> turnRight|> turnRight = turnLeft rover


[<Property>]
let ``Four rights is nop``(rover:Rover) =
    rover |> turnRight |> turnRight |> turnRight|> turnRight = rover

