using System;
using Banker.Domain.TDD.Infrastructure;

namespace Banker.Domain.TDD.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        public void Create(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}