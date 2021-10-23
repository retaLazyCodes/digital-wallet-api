using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DigitalWalletApi.Domain
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAll();
        Transaction FindById(int id);
        bool Add(Transaction transaction);
        bool Delete(int id);
        IEnumerable FindByName(string name);
    }

    public class TransactionServiceInMemory : ITransactionService
    {
        private readonly ILogger<TransactionServiceInMemory> _logger;
        private List<Transaction> _list;

        public TransactionServiceInMemory(ILogger<TransactionServiceInMemory> logger)
        {
            _logger = logger;
            _list = new List<Transaction>();
            
            _list.Add(new Transaction()
            {
                Id = 0,
                Description = "Descripcion1",
                Price = 20.0M,
                Date = new DateTime(2015, 12, 25),
                Category = new Category(),
            });
            _list.Add(new Transaction()
            {
                Id = 1,
                Description = "Descripcion2",
                Price = 15.0M,
                Date = DateTime.Now,
                Category = new Category(),
            });
        }
        
        public IEnumerable<Transaction> GetAll()
        {
            _logger.LogInformation($"Getting all transactions");;
            return _list.ToList();
        }

        public Transaction FindById(int id)
        {
            _logger.LogInformation($"Searching for transaction with id: {id}");;
            var transaction = _list.SingleOrDefault(t => t.Id == id);
            return transaction;
        }

        public bool Add(Transaction transaction)
        {
            _list.Add(transaction);
            return true;
        }

        public bool Delete(int id)
        {
            var transaction = _list.SingleOrDefault(t => t.Id == id);
            _list.Remove(transaction);
            return true;
        }

        public IEnumerable FindByName(string name)
        {
            return  _list
                .Where(t => t.Description.Contains(name)).ToList();
        }
    }
}