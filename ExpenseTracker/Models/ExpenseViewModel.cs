using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public DateTime Date { get; set; }
        
        public int DebitId { get; set; }
        [ValidateNever]
        public Debit Debit { get; set; }
        public int Amount { get; set; }
        public double Total {get; set; }
    }
}
