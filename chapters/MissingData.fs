/// <summary>Module for missing data.</summary>
module MissingData

open System

module Float =
    let tryFromString s =
        if s = "N/A" then
            None
        else
            Some (float s)
    
    let tryFromStringOr d s =
        s
        |> tryFromString
        |> Option.defaultValue d

type Student =
    { 
        Name: string
        Id: string
        MeanScore: float
        MinScore: float
        MaxScore: float
    }

module Student = 
    let fromString (s : string) = 
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]

        let scores =
            elements
            |> Array.skip 2
            // |> Array.choose Float.tryFromString
            |> Array.map (Float.tryFromStringOr 50.0)

        let averageScore = scores |> Array.average
        let lowestScore = scores |> Array.min
        let highestScore = scores |> Array.max
        {
            Name = name
            Id = id
            MeanScore = averageScore
            MinScore = lowestScore
            MaxScore = highestScore
        }

    /// <summary>Prints the student data.</summary>
    /// <param name="student">Student</param>
    let printSummary (student: Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let getSortKey (student: Student) = student.MeanScore

/// <summary>Prints the summary of a row.</summary>
let summarize filePath =
    let rows = IO.File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1 // or: let studentCount = rows.Length - 1, but this would not be consistent with further pipings
    printfn "Student count: %i" studentCount
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortByDescending (fun student -> student.MeanScore) // lambda function
    // or
    // |> Array.sortByDescending getSortKey where "let getSortKey (student: Student) = student.MeanScore"
    |> Array.iter Student.printSummary

/// <summary>Executes all the versions of missing data.</summary>
/// <param name="argv">List of arguments</param>
let main (argv: string []) =
    printfn "----------- Running missing data -----------"

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
