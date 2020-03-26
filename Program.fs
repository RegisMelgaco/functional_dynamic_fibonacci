open System


let fib n =
    let rec recFib(n, mem: Map<int, double>) =
        if mem.ContainsKey n then
            (mem.[n], mem)
        elif n <= 1 then
            let newMem = Map.ofList [0, 0.0; 1, 1.0]
            (double n, newMem)
        else
            let (fibMinus2, mem2) = recFib(n-2, mem)
            let (fibMinus1, mem1) = recFib(n-1, mem2)
            let value = fibMinus1 + fibMinus2
            (value, mem1.Add(n, value))

    let (value, _) = recFib(n, Map.empty)
    value


[<EntryPoint>]
let main argv =
    let element = argv.[0] |> int
    let value = fib element

    printfn "The %d of fibonacci is %.0f" element value
    0 // return an integer exit code
