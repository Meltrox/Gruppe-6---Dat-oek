

//These two functions is used to pull and read the html code from a given url
let url2Stream url = 
    let url = System.Uri url
    let request = System.Net.WebRequest.Create url
    let response = request.GetResponse()
    response.GetResponseStream()

let readUrl url = 
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd()


/// <summary> This function takes an url and counts the occurrences of links to other pages </summary>
/// <param name = "url"> For example "https:/valutakurser.dk"  </param>
/// <returns> The amount of links to other pages on the given url </returns>
let countLinks (url : string) : int =
    let matchString = "<a"
    let mutable counter = 0
    let str = readUrl url
    for i in 0..(str.Length - matchString.Length) do
        if str.[i..(i+1)] = matchString then
            counter <- counter + 1
        else
            ()
    counter


exception ToManyLinks of string
exception NoUrlGiven of string
[<EntryPoint>]
let main args =
    try
        if args.Length > 1 then
            raise (ToManyLinks "Error: Function given to many URL-links. Can only be given 1")
        elif args.Length = 0 then
            raise (NoUrlGiven "No url is given")
        else
            let strUrl = args.[0]
            printfn "%A" (countLinks strUrl)
            0
    with
        | ToManyLinks msg -> printfn "%A" msg; 1
        | NoUrlGiven msg -> printfn "%A" msg; 1
        | Ex -> printfn "%A" "Unknown error! Check that the url is given as a https:/... and is spelled correct" ; 1


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

