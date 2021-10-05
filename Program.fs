open System

let chapterFunctions =
    [|
        ControlFlow.main;
        LoopsIterations.main
    |]

[<EntryPoint>]
let main argv = 
    for mainFunction in chapterFunctions do
        mainFunction argv
    0