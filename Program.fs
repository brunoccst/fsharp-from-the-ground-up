// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv = // string[] -> int
    let mutable person = "Anonymous Person"
    if argv.Length > 0 then
        person <- argv.[0]
    printfn "Hello %s from my F# program!" person
    0 // return an integer exit code