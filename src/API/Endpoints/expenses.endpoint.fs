module endpoints.expenses

open Microsoft.AspNetCore.Http
open entities.expense
open logic.expenses
open routing
open helper

let all (context:HttpContext) =
    json context expenses

let add exp =
    logic.expenses.addExpense exp

let parseTo<'a> (context:HttpContext) =
    //try 
        System.Text.Json.JsonSerializer.Deserialize<'a> context.Request.Body
   // with exc

let create (context:HttpContext) =
    let data = parseTo context
    let exp = Expense.create data
    logic.expenses.addExpense exp

    context.Response.StatusCode <- 201
    context.Response.ContentType <- "application/json"
    context.Response.WriteAsJsonAsync exp.id

let routes = [
    GET, "/expenses", all
    POST, "/expenses", create
]