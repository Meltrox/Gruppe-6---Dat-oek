module readNWrite

//9g0
///<summary> This fucntion takes a filename as a string and returns the contents of the text file as a string option</summary>
/// <remarks> If any exceptions is raised the fuction will return None. This is for example if the filename given does not
/// exist at the current directory </remarks>
/// <param name = "filename"> A filename as a string </param>
/// <returns> The content of a text file as a string option </returns>
let readFile (filename : string) : string option = 
  try
    let reader = System.IO.File.OpenText filename
    Some (reader.ReadToEnd())
  with
    | ex -> None

//HEJ PETER
//9g1
///<summary> This function uses the function (readFile) to return the combined contents of an arbitrary number of text files </summary>
/// <remarks> If given an empty string list the function returns None </remarks>
/// <param name = "filenames"> A string list containing the names of text files </param>
/// <returns> The combined contents of the given files as a string option </returns>
let cat (filenames : string list) : string option = 
    if filenames.Length = 0 then
        None //Hvis der ikke bliver givet en liste med nogle filer, returneres None
    else
        let rec catHelp (filenames : string list) =
            match filenames with
            | [] -> Some ""
            | hd :: tl -> match readFile hd with
                          | Some a -> (Option.bind (fun x -> Some (x + a)) (catHelp (tl)))
                          | None -> None //Hvis en af filerne ikke eksisterer vil (readFile) retunere None
        catHelp filenames

//9g1
///<summary> This function uses the functions (readFile) and (cat) to return the combined contents of an arbitrary number of text files
/// However where the contents of the files is reversed </summary>
/// <param name = "filenames"> A string list containing the names of text files </param>
/// <returns> The combined contents of the given files as a string option, but where the contents of the files is in reverse order
/// and every line is reversed aswell </returns>
let tac (filenames : string list) : string option =
    match cat filenames with
    | None -> None
    | Some a -> Some (a |> Seq.rev |> System.String.Concat) 