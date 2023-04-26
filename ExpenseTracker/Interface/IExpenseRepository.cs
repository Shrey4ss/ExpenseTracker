using ExpenseTracker.Models;

namespace ExpenseTracker.Interface
{
    public interface IExpenseRepository
    {
        public IEnumerable<Debit> GetAllDebit();

        public IEnumerable<Expense> GetAllExpense(int id);
        public Expense? GetLastId(int id);
        public Expense GetId(int id);
        bool Add(Expense expense);
        bool Delete (Expense expense);
        bool Save();

    }
}
