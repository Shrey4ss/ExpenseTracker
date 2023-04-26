using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { 
            
        }
       public DbSet<Debit> Debits { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        

       
    }
}
