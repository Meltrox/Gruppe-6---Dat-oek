let readFile (filename : string) : string option = 
  try
    let reader = System.IO.File.OpenText filename
    Some (reader.ReadToEnd())
  with
    | ex -> None

// let cat (lst : string list) =
//     if lst.Length = 0 then
//         None
//     else
//         let rec catHelp lst = 
//             match lst with
//             | [] -> Some ""
//             | hd :: tl -> match readFile hd with
//                           | Some a -> Option.bind (fun x -> Some (a + x)) (catHelp (tl))
//                           | None -> None 
//         catHelp lst
// printfn "%A" (cat ["readNwrite.fs"; "Johannes"])

// let tac (lst : string list) =
//     match 

printfn "%A" ("Joha\nnnes\nMatt\nias\n" |> Seq.rev |> System.String.Concat)
printfn "%A" "Joha\nnnes\nMatt\nias\n"

// readFile "readNWrite.fs" + cat ["Testaffunktioner.fsx"]
// cat ["Testaffunktioner.fsx"] = readFile "Testaffunktioner.fsx" + cat []
// cat [] = Some ("")
// readFile "Testaffunktioner.fsx" + "" -> Some (a) + Some (b)
// 
//Test af readFile

// let someAdd = (Option.bind (fun x -> Some (x + 2)) (Some (3)))
// printfn "%A" someAdd
printfn "%A" (Option.bind (fun x -> Some ("123123" + x)) (Some "abcabc"))