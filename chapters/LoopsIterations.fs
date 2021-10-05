/// <summary>Module for loops/iterations functions.</summary>
module LoopsIterations

let sayHello person =
    printfn "Hello %s from the loop/iteration" person

/// <summary>Iterates through the array using an index for loop, printing each value of the array.</summary>
/// <param name="argv">List of arguments</param>
let iterateWithIndexForLoop (argv: string []) =
    for i in 0 .. argv.Length - 1 do
        let person = argv.[i]
        sayHello person

/// <summary>Iterates through the array using an iterator, printing each value of the array.</summary>
/// <param name="argv">List of arguments</param>
let iterateWithIterator (argv: string []) =
    for person in argv do
        sayHello person

/// <summary>Iterates through the array using Array.iter, printing each value of the array.</summary>
/// <param name="argv">List of arguments</param>
let iterateWithArrayIter (argv: string []) =
    Array.iter sayHello argv

/// <summary>Executes all the versions of loops/iterations functions.</summary>
/// <param name="argv">List of arguments</param>
let main (argv: string[]) =
    printfn "----------- Running loops/iterations functions -----------"
    
    printfn "---- iterateWithIndexForLoop"
    iterateWithIndexForLoop argv

    printfn "---- iterateWithIterator"
    iterateWithIterator argv

    printfn "---- iterateWithArrayIter"
    iterateWithArrayIter argv
    
