module helper

open Microsoft.AspNetCore.Http

let text (context:HttpContext) message =
    context.Response.ContentType <- "text/plain"
    context.Response.StatusCode <- 200
    context.Response.WriteAsync message

let json<'a> (context:HttpContext) (data:'a) =
    context.Response.ContentType <- "application/json"
    context.Response.StatusCode <- 200
    context.Response.WriteAsJsonAsync data
