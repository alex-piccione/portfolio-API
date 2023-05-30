//namespace Portfolio.API

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System.Threading.Tasks
open System


type WebApplication with 
    member this.Get (path:string) (handle:HttpContext -> Task) =
        this.MapGet(path, RequestDelegate handle) |> ignore

    member this.create (path:string) (handle:HttpContext -> Task) =
        this.MapPost(path, RequestDelegate handle) |> ignore




let handleRequest (context: HttpContext) : Task =
    //async {
        context.Response.StatusCode <- 200
        context.Response.ContentType <- "text/plain"
        context.Response.WriteAsync("Hello, world!") //|> Async.AwaitTask
    //} |> Async.StartAsTask

//let get (task: HttpContext -> Task) = RequestDelegate task



let builder = WebApplication.CreateBuilder()
let app = builder.Build()

//let todoItemsHandler (context : HttpContext) (db : TodoDb) : Async<Unit> =
//    let! todoItems = db.Todos.ToListAsync()
//    return! context.Response.WriteAsJsonAsync(todoItems)

app.Get "/" endpoints.root.get

app.create "/expenses" endpoints.expenses.create

//app.MapGet("/", RequestDelegate(handleRequest)) |> ignore
app.MapGet("/hello", RequestDelegate(handleRequest)) |> ignore
app.MapGet("/aa", Func<string>(fun () -> "")) |> ignore

app. Run("http://localhost:8085");