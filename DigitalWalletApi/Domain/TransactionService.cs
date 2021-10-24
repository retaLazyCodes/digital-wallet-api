using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DigitalWalletApi.Data;
using Microsoft.Extensions.Logging;

namespace DigitalWalletApi.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly DigitalWalletDbContext _db;

        public TransactionService(ILogger<TransactionService> logger, DigitalWalletDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IEnumerable<Transaction> GetAll()
        {
            _logger.LogInformation($"Getting all transactions");;
            return _db.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetIncomes()
        {
            return _db.Transactions.Where(t => t.IsIncome == true);
        }

        public IEnumerable<Transaction> GetExpenses()
        {
            return _db.Transactions.Where(t => t.IsIncome != true);
        }

        public Transaction FindById(int id)
        {
            _logger.LogInformation($"Searching for transaction with id: {id}");;
            var transaction = _db.Transactions.SingleOrDefault(t => t.Id == id);
            return transaction;
        }

        public bool Add(Transaction transaction)
        {
            var expense = new Transaction
            {
                Description = transaction.Description,
                Price = transaction.Price,
                CategoryId = transaction.CategoryId,
                Date = transaction.Date,
                IsIncome = transaction.IsIncome
            };
            
            _db.Transactions.Add(expense);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var transaction = _db.Transactions.SingleOrDefault(t => t.Id == id);
            if (transaction != null) {
                _db.Transactions.Remove(transaction);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable FindByName(string name)
        {
            return _db.Transactions.Where(t => t.Description.ToLower()
                    .Contains(name)).ToList();
        }
    }
}