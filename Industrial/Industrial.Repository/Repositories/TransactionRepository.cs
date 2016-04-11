using System;
using System.Collections.Generic;
using Industrial.Data.Domain;
using Industrial.Models.EventArgsAndException;

namespace Industrial.Repository.Repositories
{
    public class TransactionRepository : ITransactionRepository {
        public IList<Transaction> GetTransactions(TransactionFilter filter)
        {
            throw new NotImplementedException();
        }

        public void GetTransactionsAsync(TransactionFilter filter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<GetTransactionFinishedEventArg> GetTransactionsCompleted;
        public void SaveTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void SaveTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<RepositoryTaskFinishedEventArgs> SaveTransactionCompleted;
        public void DeleteTransactions(Transaction[] transactions)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransactionsAsync(Transaction[] transactions)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<DeleteTransactionsFinishedEventArg> DeleteTransactionsCompleted;
        public Transaction GetNewTransaction()
        {
            throw new NotImplementedException();
        }
    }
}