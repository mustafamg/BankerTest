using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banker.Domain.TDD.Model;

namespace Banker.Domain.TDD.Infrastructure
{
    public interface IAccountsRepository
    {
        List<Account> List();
        Account Get(int accountId);
        void Update(Account account);
    }
}
