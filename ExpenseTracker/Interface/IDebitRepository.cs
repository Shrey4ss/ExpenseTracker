using ExpenseTracker.Models;

namespace ExpenseTracker.Interface
{
    public interface IDebitRepository
    {
        bool Add (Debit debit);
        public Debit GetId(int id);

        bool Save();
    }
}
