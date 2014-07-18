using System;

namespace Banker.Domain
{
    public class AccountantService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IAccountsRepository _accountsRepository;
        public AccountantService(IAccountsRepository accountsRepository, ITransactionsRepository transactionsRepository)
        {
            this._transactionsRepository = transactionsRepository;
            this._accountsRepository = accountsRepository;
        }

        public Account Deposit(int accountId, decimal amount)
        {
            var account = _accountsRepository.Get(accountId);
            account.Balance += amount;
            _accountsRepository.Update(account);
            _transactionsRepository.Create(accountId, amount);
            return account;
        }

        public Account Withdraw(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public class AccountsRepository:IAccountsRepository
    {

        public Account Get(int accountId)
        {
            //todo: logic to get data from db
            throw new NotImplementedException();
        }

        public int Create(Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account account)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAccountsRepository
    {
        Account Get(int customerId);
        int Create(Account account);
        void Update(Account account);
        void Delete(Account account);
    }

    public interface ITransactionsRepository
    {
        Transaction Get(int transactionId);
        int Create(int accountId, decimal amount);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        public Transaction Get(int transactionId)
        {
            throw new NotImplementedException();
        }

        public int Create(int accountId,decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    
}
