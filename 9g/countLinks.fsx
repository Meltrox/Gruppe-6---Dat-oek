
let url2Stream url = 
    let url = System.Uri url
    let request = System.Net.WebRequest.Create url
    let response = request.GetResponse()
    response.GetResponseStream()

let readUrl url = 
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd()

let matchString = "<a href"
let urlString = readUrl "https://www.valutakurser.dk/"
let countLinks (str : string) =
    let mutable counter = 0
    for i in 0..(str.Length - matchString.Length) do
        if str.[i..(i+6)] = matchString then
            counter <- counter + 1
        else
            ()
    counter
printfn "%A" (countLinks urlString)

[<EntryPoint>]
let main args =
    try
        if args.Length > 1 then
            raise (ToManyLinks "Error: Function given to many URL-links. Can only be given 1")
        else
            let str = args.[0]
            let urlString = readUrl str
            printfn "%A" (countLinks urlString)
            0
    with
        | ToManyLinks msg -> printfn "%A" msg; 1
        | ex -> printfn "%A" ex; 1


// open System.Net
// open System
// open System.IO

// let fetchUrl (url : string) : string =
//     let req = WebRequest.Create(Uri(url))
//     use resp = req.GetResponse()
//     use stream = resp.GetResponseStream()
//     use reader = new IO.StreamReader(stream)
//     reader.ReadToEnd()
// let str = fetchUrl "http://www.valutakurser.dk"
// printfn "%s" str

//   with
//     | ex -> printfn "Error"; 1  

// let url = "http://h2020.myspecies.info"
// exception ToManyLinks of string

[<EntryPoint>]
let main args =
    try
        if args.Length > 1 then
            raise (ToManyLinks "Error: Function given to many URL-links. Can only be given 1")
        else
            let str = args.[0]
            let urlString = readUrl str
            printfn "%A" (countLinks urlString)
            0
    with
        | ToManyLinks msg -> printfn "%A" msg; 1
        | ex -> printfn "%A" ex; 1
    