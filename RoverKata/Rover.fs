module Rover

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
    let add p1 = fun p2 -> { x = (p1.x + p2.x) % planet.width; y = (p1.y + p2.y) % planet.height}

    let moveForward rover = {rover with location = add rover.location (step rover.facing) }
    let moveBackward rover = {rover with location = add rover.location (opposite (step rover.facing)) }

    let rightOf direction =
        match direction with
        | N -> E
        | E -> S
        | S -> W
        | W -> N

    let leftOf direction =
        match direction with
        | N -> W
        | W -> S
        | S -> E
        | E -> N

    let turnLeft rover = {rover with facing=leftOf rover.facing}
    let turnRight rover = {rover with facing=rightOf rover.facing}

    let move towards =
        match towards with
        | F ->  moveForward
        | B ->  moveBackward
        | L -> turnLeft
        | R -> turnRight

    let moveForwardsOne() =
        (move F) {location={x=10;y=10}; facing=N} = {location={x=10;y=9}; facing=N}

    let moveBackwardsOne() =
        (move B) {location={x=10;y=10}; facing=N} = {location={x=10;y=11}; facing=N}

    let leftOfTest() =
        leftOf N = W
        && leftOf S = E

    let test =
        leftOfTest()
        && moveForwardsOne()
        && moveBackwardsOne()
        && true
