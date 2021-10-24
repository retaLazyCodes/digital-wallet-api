using System;
using System.Collections;
using System.Collections.Generic;

namespace DigitalWalletApi.Domain
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetIncomes();
        IEnumerable<Transaction> GetExpenses();
        Transaction FindById(int id);
        bool Add(Transaction transaction);
        bool Delete(int id);
        IEnumerable FindByName(string name);
    }
}