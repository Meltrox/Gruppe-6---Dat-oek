module readNWrite
[<EntryPoint>]
let main args =
    let list = args |> List.ofArray
    match (readNWrite.cat list) with
    | None -> printfn "One or more files do not exist or no filenames given"; 1
    | Some a -> printfn "%s" (a); 0
