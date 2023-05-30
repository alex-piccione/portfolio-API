module entities.expense

open System

type Expense = { 
    id:string; 
    date:DateTime; 
    currencyCode:string; 
    amount:decimal; 
    description:string }
    with
    static member create (date, currencyCode, amount, description) =
        {id=Guid.NewGuid().ToString(); date=date; currencyCode=currencyCode; amount=amount; description=description}
