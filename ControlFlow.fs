/// <summary>Module for control flow functions.</summary>
module ControlFlow

/// <summary>Executes a conditional value assignment using a mutable variable, then print it.</summary>
/// <param name="argv">List of arguments</param>
let conditionalWithMutable (argv: string[]) = 
    let mutable person = "Anonymous Person"
    if argv.Length > 0 then
        person <- argv.[0]
    printfn "Hello %s from the control flow - conditionalWithMutable" person

/// <summary>Executes a conditional value assignment directly with an if/else block, then print it.</summary>
/// <param name="argv">List of arguments</param>
let conditionalWithIfElse (argv: string[]) =
    let person =
        if argv.Length > 0 then
            argv.[0]
        else
            "Anonymous Person"
    printfn "Hello %s from the control flow - conditionalWithIfElse" person

/// <summary>Executes all the versions of control flow functions.</summary>
/// <param name="argv">List of arguments</param>
let main (argv: string[]) =
    printfn "----------- Running control flow functions -----------"
    conditionalWithMutable argv
    conditionalWithIfElse argv
    