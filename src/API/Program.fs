open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System.Threading.Tasks
open System
open routing


let getEnv name defaultValue =
    match Environment.GetEnvironmentVariable(name) with
    | value when String.IsNullOrEmpty(value) -> defaultValue
    | value -> value

let port = getEnv variables.port "8005"


let handleRequest (context: HttpContext) : Task =
    //async {
        context.Response.StatusCode <- 200
        context.Response.ContentType <- "text/plain"
        context.Response.WriteAsync("Hello, world!") //|> Async.AwaitTask
    //} |> Async.StartAsTask

//let get (task: HttpContext -> Task) = RequestDelegate task

//let todoItemsHandler (context : HttpContext) (db : TodoDb) : Async<Unit> =
//    let! todoItems = db.Todos.ToListAsync()
//    return! context.Response.WriteAsJsonAsync(todoItems)


let builder = WebApplication.CreateBuilder()
let app = builder.Build()

app 
|> addRoutes (endpoints.root.routes)
|> addRoutes (endpoints.info.routes)
|> addRoutes (endpoints.expenses.routes)
|> ignore

app.MapGet("/hello", RequestDelegate(handleRequest)) |> ignore

app. Run($"http://localhost:{port}");