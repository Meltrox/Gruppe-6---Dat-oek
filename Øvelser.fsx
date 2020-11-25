
//Opgave 0 + 1 - fakultet
exception ArgumentTooBig of string
let fac (n : int) =
  try
    if n < 1 then 
        raise (System.ArgumentException "Error: Trying to take the faculty of n < 1")
    else if n > 13 then
        raise (ArgumentTooBig "Error: Calculation would result in an overflow")
    else
        let rec fac2 (n1 : int) =
            n1 * (fac2 (n1 - 1))
        printfn "%A" (fac2 n)
        0
    with
        | ex when n < 1 -> printf "%A - Return: " ex.Message; 1
        | ArgumentTooBig msg -> printf "%A - Return: " msg; System.Int32.MaxValue
printfn "%A" (fac 0)
printfn "%A" (fac 30001)
// try
//     printfn "%A" (fac 5)
// with
//     | ex -> printfn "%A" ex.Message

//Opgave 2
let facFailwith (n : int) : int =
  try
    if (n < 1) then
        failwith "Error: Trying to take the faculty of n < 1"
    else if (n > 30000) then
        failwith "Error: Calculation would result in an overflow"
    else
        let rec fac2 (n1 : int) =
            n1 * (fac2 (n1 - 1))
        fac2 n
  with
      | Failure msg -> printfn "%A" msg; 1
facFailwith 40000
facFailwith 0

// //Opgave 3
// let facOption (n : int) : int option =
//         let rec fac2 (n1 : int) =
//             match n1 with
//             | x when x = 0 -> 1
//             | _ -> n1 * (fac2 (n1 - 1))
//         match (fac n) with
//         | x when x = 0 -> 1
//         | _ -> n * (facOption (n1 - 1))


    







