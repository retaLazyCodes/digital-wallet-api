using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DigitalWalletApi.Data;
using Microsoft.Extensions.Logging;

namespace DigitalWalletApi.Domain
{
    public class ExpenseService : ITransactionService
    {
        private readonly ILogger<ExpenseService> _logger;
        private readonly DigitalWalletDbContext _db;

        public ExpenseService(ILogger<ExpenseService> logger, DigitalWalletDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IEnumerable<Transaction> GetAll()
        {
            _logger.LogInformation($"Getting all transactions");;
            return _db.Expenses.ToList();
        }

        public Transaction FindById(int id)
        {
            _logger.LogInformation($"Searching for transaction with id: {id}");;
            var transaction = _db.Expenses.SingleOrDefault(t => t.Id == id);
            return transaction;
        }

        public bool Add(Transaction transaction)
        {
            var expense = new Expense
            {
                Description = transaction.Description,
                Price = transaction.Price,
                Category = transaction.Category,
                Date = transaction.Date
            };
            
            _db.Expenses.Add(expense);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var transaction = _db.Expenses.SingleOrDefault(t => t.Id == id);
            if (transaction != null) {
                _db.Expenses.Remove(transaction);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable FindByName(string name)
        {
            return _db.Expenses.Where(t => t.Description.ToLower()
                    .Contains(name)).ToList();
        }
    }
}