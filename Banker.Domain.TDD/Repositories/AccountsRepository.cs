using Banker.Domain.TDD.Infrastructure;
using Banker.Domain.TDD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banker.Domain.TDD.Repositories
{
    public class AccountsRepository:IAccountsRepository
    {
        List<Account> _account;
        public AccountsRepository()
        {
            _account = new List<Account>{
                new Account{ Id=1, Balance=500},
                new Account{Id=2,Balance =300},
                new Account{Id=3,Balance=1000}
            };
        }
        public List<Model.Account> List()
        {
            return _account;
        }

        public Model.Account Get(int accountId)
        {
            return _account.Find(a => a.Id == accountId);
        }

        public void Update(Model.Account account)
        {
            throw new NotImplementedException();
        }
    }
}
