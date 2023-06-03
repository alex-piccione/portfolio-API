module helper

open Microsoft.AspNetCore.Http

type created<'a> = { id:'a}

let text (context:HttpContext) message =
    context.Response.ContentType <- "text/plain"
    context.Response.StatusCode <- 200
    context.Response.WriteAsync message

let json<'a> (context:HttpContext) (data:'a) =
    context.Response.ContentType <- "application/json"
    context.Response.StatusCode <- 200
    context.Response.WriteAsJsonAsync data

let created<'a> (context:HttpContext) (data:'a) =
    context.Response.ContentType <- "application/json"
    context.Response.StatusCode <- 201
    context.Response.WriteAsJsonAsync data

let createdId<'a> (context:HttpContext) (id:'a) =
    context.Response.ContentType <- "application/json"
    context.Response.StatusCode <- 201
    context.Response.WriteAsJsonAsync {id=id}

let deserialize<'a> (context:HttpContext) =
    try 
        System.Text.Json.JsonSerializer.Deserialize<'a> context.Request.Body
    with 
    | exc ->  raise (System.Exception($"Cannot deserialize to {typeof<'a>}", exc))