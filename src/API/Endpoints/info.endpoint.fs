module endpoints.info 

open Microsoft.AspNetCore.Http
open routing
open helper

type info = {version:string; startedAt:System.DateTime}
let info = {version="123"; startedAt=System.DateTime.UtcNow}

let acceptJson (context:HttpContext) =
    context.Request.Headers.Accept.Count > 0 && 
    context.Request.Headers.Accept.ToArray() 
    |> Array.exists (fun v -> v.EndsWith("/json"))


let get (context:HttpContext) =
    if acceptJson context 
    then json context info
    else text context $"version: {info.version} - startedAt: {info.startedAt:o}"


let routes = [
    GET, "/info", get
]

