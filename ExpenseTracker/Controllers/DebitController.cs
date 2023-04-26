using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class DebitController : Controller
    {
        private readonly IDebitRepository _debitRepository;


        public DebitController(IDebitRepository debitRepository)
        {
            _debitRepository = debitRepository;
         
        }
        [HttpGet]
        public IActionResult DebitIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DebitIndex(Debit debit)
        {
            if(ModelState.IsValid)
            {
                Debit de = new Debit()
                {
                  Amount = debit.Amount,
                  Date = debit.Date,
                };
              
                _debitRepository.Add(de);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
