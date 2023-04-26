using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expense;
        private readonly IDebitRepository _debit;

        public ExpenseController(IExpenseRepository expense,IDebitRepository debit)
        {
            _expense = expense;
            _debit = debit;
        }
        public IActionResult ExpenseIndex()
        {
            IEnumerable<Debit> debit = _expense.GetAllDebit();
            return View(debit);
        }

        public IActionResult Add(int id,Expense expense)
        {
            var expenseFromDb = _expense.GetLastId(id);
            var debitFromDb = _debit.GetId(id);
            if(expenseFromDb == null)
            {
                ViewBag.Total = 1;
                ViewBag.Amount = 0;
                ViewBag.Id = id;
                return View();
            }
            ViewBag.Total = expenseFromDb.total;
            ViewBag.Amount = debitFromDb.Amount;
            ViewBag.Id=id;
            return View();
        }

       [HttpPost]
        public IActionResult Add(Expense expense,int id)
        {
            var expenseFromDb = _expense.GetLastId(id);
            var debitFromDb = _debit.GetId(id);

            
            if (ModelState.IsValid)
            {
                if (expenseFromDb == null)
                {
                    if(expense.Amount > debitFromDb.Amount)
                    {
                        TempData["error"] = "Amount is Exceeding debited Amount";
                        ViewBag.Total = 0;
                        ViewBag.Amount = 1;
                    }
                    else
                    {
                        Expense exp = new Expense()

                        {
                            ExpenseName = expense.ExpenseName,
                            Amount = expense.Amount,
                            Date = expense.Date,
                            DebitId = id,
                            total = expense.Amount,

                        };

                        _expense.Add(exp);
                        return RedirectToAction("Summary", "Summary", new { id = id });
                    }
                   
                }
                else
                {
                    if ( expenseFromDb.total + expense.Amount > debitFromDb.Amount)
                    {
                        TempData["error"] = "Expense is Exceeding debited Amount";
                        ViewBag.Total = expenseFromDb.total + expense.Amount;
                        ViewBag.Amount = debitFromDb.Amount;
                        return View();
                        
                    }
                    else
                    {
                        Expense exp = new Expense()
                        {
                            ExpenseName = expense.ExpenseName,
                            Amount = expense.Amount,
                            Date = expense.Date,
                            DebitId = id,
                            total = expense.Amount + expenseFromDb.total,

                        };

                        _expense.Add(exp);
                       
                        return RedirectToAction("Summary", "Summary", new { id = id });
                    }
                }
              


            }
          
            return View();
        }
    }
}
