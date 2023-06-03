module endpoints.root
open routing

open Microsoft.AspNetCore.Http


//let getRoot (context : HttpContext) (db : TodoDb) : Async<Unit> =
//    let! todoItems = db.Todos.ToListAsync()
//    return! context.Response.WriteAsJsonAsync(todoItems)

let getRoot (context:HttpContext) : Async<unit> =
    context.Response.WriteAsJsonAsync("Hello world!") |> Async.AwaitTask


let get (context:HttpContext) =
    context.Response.StatusCode <- 200
    context.Response.ContentType <- "text/plain"
    context.Response.WriteAsJsonAsync "Hello world!"

//let getRoot_2 (context : HttpContext) : Async<unit> =
//    Func<> context.Response.WriteAsJsonAsync("Hello world!") |> Async.AwaitTask

let greetAsync () : Async<unit> =
    async {
        do! Async.Sleep(1000)
        printfn "Hello World!"
    }


let routes = [
    GET, "/", get
]
