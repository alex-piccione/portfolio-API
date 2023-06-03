module routing

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System.Threading.Tasks

type Verb = GET | POST
type route = Verb * string * (HttpContext -> Task)

let addRoutes (routes: route list) (app:WebApplication) =
    for (verb, path, handle) in routes do
        match verb with
        | GET -> app.MapGet(path, handle) |> ignore
        | POST -> app.MapPost(path, handle) |> ignore
    app