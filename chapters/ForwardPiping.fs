/// <summary>Module for forward piping functions.</summary>
module ForwardPiping

open System

let sayHello person =
    printfn "Hello %s from the forward piping" person

let isValid person =
    not(String.IsNullOrWhiteSpace person)
    // or:
    // String.IsNullOrWhiteSpace person |> not

let isAllowed person =
    person <> "Eve"
    
/// <summary>Executes a loop/iteration function using forward piping.</summary>
/// <param name="argv">List of arguments</param>
let pipingTheParam (argv: string[]) = 
    argv |> Array.iter sayHello

/// <summary>Executes a loop/iteration function using forward piping, but broken into the next line.</summary>
/// <param name="argv">List of arguments</param>
let pipingTheParamOnTheNextLine (argv: string[]) = 
    argv
    |> Array.iter sayHello

/// <summary>Executes a loop/iteration function using multiple forward piping.</summary>
/// <param name="argv">List of arguments</param>
let multiplePiping (argv: string[]) = 
    argv
    |> Array.filter isValid
    |> Array.filter isAllowed
    |> Array.iter sayHello

/// <summary>Executes all the versions of forward piping functions.</summary>
/// <param name="argv">List of arguments</param>
let main (argv: string[]) =
    printfn "----------- Running forward piping functions -----------"

    printfn "--- pipingTheParam"
    pipingTheParam argv

    printfn "--- pipingTheParamOnTheNextLine"
    pipingTheParamOnTheNextLine argv

    printfn "--- multiplePiping"
    multiplePiping argv

    