using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        public DateTime Date { get; set;}
        [ForeignKey("Debit")]
        public int DebitId { get; set;}
        [ValidateNever]
        public Debit Debit { get; set; }
        [Required]
        public int Amount { get; set;}
        public double total { get; set;}
    }
}
