/// <summary>Module for collection functions.</summary>
module CollectionFunctions

open System

/// <summary>Prints the mean score of a row.</summary>
/// <param name="row">Row</param>
let printMeanScore (row: String) =
    let elements = row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]
    let meanScore =
        elements
        |> Array.skip 2
        |> Array.averageBy float
    printfn "%s\t%s\t%0.1f" name id meanScore

/// <summary>Prints the summary of a row.</summary>
let summarize filePath =
    let rows = IO.File.ReadAllLines filePath
    let studentCount = ( rows |> Array.length) - 1 // or: let studentCount = rows.Length - 1, but this would not be consistent with further pipings
    printfn "Student count: %i" studentCount
    rows
    |> Array.skip 1
    |> Array.iter printMeanScore

/// <summary>Executes all the versions of collection functions.</summary>
/// <param name="argv">List of arguments</param>
let main (argv: string[]) =
    printfn "----------- Running collection functions -----------"

    if argv.Length = 1 then
        let filePath = argv.[0]
        if IO.File.Exists filePath then
            printfn "Processing %s" filePath
            summarize filePath
            0
        else
            printfn "File not found: %s" filePath
            2
    else 
        printfn "Please specify a file"
        1
