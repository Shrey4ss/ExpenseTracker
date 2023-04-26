using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

namespace ExpenseTracker.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IExpenseRepository _expense;

        public SummaryController(IExpenseRepository expense )
        {
            _expense = expense;
        }
        public IActionResult SummaryIndex()
        {
            IEnumerable<Debit> expense = _expense.GetAllDebit();
            return View(expense);
            
        }
        public IActionResult Summary(int id) 
        {
            IEnumerable<Expense> expense = _expense.GetAllExpense(id);
            ViewBag.Id = id;
            return View(expense);
        }
        public IActionResult Delete(int id)
        {
            var delexp = _expense.GetId(id);
            int debtid = delexp.DebitId; //store debitID of that expense in varialbe
            double tot = 0; //set total as 0;

            if (delexp != null)  // if that particular expense is not null then
            {
                _expense.Delete(delexp);   //delete the expense
                var newTotal = _expense.GetAllExpense(debtid); // get all expense of that debitid


                if (newTotal != null) // if  expense of that particular debitid exist
                {
                   foreach(var item in newTotal)
                    {
                        item.total = item.Amount+tot;
                        tot=item.total;
                        _expense.Save();
                    }
                }
            }
            return RedirectToAction("Summary",new { id = debtid });

        }
    }
}
