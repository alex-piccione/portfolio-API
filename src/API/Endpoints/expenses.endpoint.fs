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

let create (context:HttpContext) =
    let data = deserialize context
    let exp = Expense.create data
    logic.expenses.addExpense exp

    createdId context (exp.id)

let routes = [
    GET, "/expenses", all
    POST, "/expenses", create
]