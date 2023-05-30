module endpoints.expenses

open entities.expense
open logic.expenses
open Microsoft.AspNetCore.Http

let all ():Expense list =
    expenses

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
