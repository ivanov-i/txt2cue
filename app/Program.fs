// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.IO

let fileReader file = seq {
    use reader = new System.IO.StreamReader(File.OpenRead(file))
    while not reader.EndOfStream do
        yield reader.ReadLine() }  
 
let skipTrackNumber (str: string) = 
    str.TrimStart("1234567890 ".ToCharArray())

[<EntryPoint>]
let main argv = 
    let strings = fileReader "songs.txt"
    let removedTrackNum = strings |> Seq.map skipTrackNumber
    printfn "%A" removedTrackNum
    0 // return an integer exit code
            