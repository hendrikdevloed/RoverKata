open System.Security.Cryptography.X509Certificates

type Direction = N | E| S | W

type Point = {x:int; y:int}

type Command = F | B | L | R

type Grid = { width : int; height : int }

let planet : Grid = { width=20; height=20 }

type Rover = { location: Point; facing: Direction }

let step direction =
    match direction with
    | N -> {x=0;y = -1}
    | E -> {x=1;y=0}
    | S -> {x=0;y=1}
    | W -> {x = -1;y=0}

let opposite direction = {x = - direction.x ; y = -direction.y}
let add p1 = fun p2 -> {
    x = (p1.x + p2.x);
    y = p1.y + p2.y
}

let moveForward rover = {rover with location = add rover.location (step rover.facing) }
let moveBackward rover = {rover with location = add rover.location (opposite (step rover.facing)) }

let move rover towards =
    match towards with
    | F ->  moveForward rover
    | B ->  moveBackward rover
    | _ -> id rover

let moveForwardsOne() =
    move {location={x=10;y=10}; facing=N} F = {location={x=10;y=9}; facing=N}

let moveBackwardsOne() =
    move {location={x=10;y=10}; facing=N} B = {location={x=10;y=11}; facing=N}

let test =
    moveForwardsOne()
    && moveBackwardsOne()
    && true
