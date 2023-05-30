module logic.expenses

open entities.expense


let mutable expenses:Expense list = []

let addExpense expense: unit = 
    expenses <- expenses @ [expense]

let removeExpense id: unit =
    match expenses |> List.tryFindIndex (fun x -> x.id = id) with 
    | Some index -> expenses <- expenses[0..index] @ expenses[index..] 
    | _ -> ()


// test

let ex1:Expense = Expense.create(System.DateTime.UtcNow, "EUR", 1m, "test 1")   //{id="1"; date=System.DateTime.UtcNow; currencyCode="EUR"; amunt=1m; description="aaa"}

let ex2:Expense = Expense.create(System.DateTime.UtcNow, "EUR", 2m, "test 2")   //{id="1"; date=System.DateTime.UtcNow; currencyCode="EUR"; amunt=1m; description="aaa"}
addExpense ex1

for exp in expenses do
    printf "ex: %s" exp.description

