using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            return Save();
        }

        public bool Delete(Expense expense)
        {
            _context.Expenses.Remove(expense);
            return Save();
        }

        public IEnumerable<Debit> GetAllDebit()
        {
            IEnumerable<Debit> debits = _context.Debits.ToList();
            return debits;
        }

        public IEnumerable<Expense> GetAllExpense(int id)
        {
            IEnumerable<Expense> expenses = _context.Expenses.Include(i=>i.Debit).Where(u=>u.DebitId==id).ToList();
            return expenses;
        }

        public Expense GetId(int id)
        {
            var ExpId = _context.Expenses.FirstOrDefault(u=>u.Id==id);
            return ExpId;
        }

        public Expense GetLastId(int id)
        {
            var DebitbyId = _context.Expenses.OrderBy(u=>u.Id).LastOrDefault(d => d.Debit.Id == id);
            return DebitbyId == null ? null : DebitbyId;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
