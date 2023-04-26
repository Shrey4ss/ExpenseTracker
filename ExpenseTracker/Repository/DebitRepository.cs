using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class DebitRepository : IDebitRepository
    {
        private readonly ApplicationDbContext _context;

        public DebitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Debit debit)
        {
            _context.Debits.Add(debit);
            return Save();
        }

        public Debit GetId(int id)
        {
            var DebId = _context.Debits.FirstOrDefault(u => u.Id == id);
            return DebId;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
