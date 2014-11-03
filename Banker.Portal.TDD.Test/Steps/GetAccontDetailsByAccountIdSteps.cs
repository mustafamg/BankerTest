using System;
using System.Web.Mvc;
using Banker.Domain.TDD.Infrastructure;
using Banker.Domain.TDD.Model;
using Banker.Portal.Controllers;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Banker.Portal.TDD.Test.Steps
{
    [Binding]
    public class GetAccontDetailsByAccountIdSteps
    {
        private AccountsController _sut;
        private ViewResult _result;

        [Given(@"I have the following accounts:")]
        public void GivenIHaveTheFollowingAccounts(Table table)
        {
            var accountRepoMock = new Mock<IAccountsRepository>();
            foreach (var row in table.Rows)
            {
                var account = new Account() {Id = Convert.ToInt32(row["AccountId"]), Balance = Convert.ToDecimal(row["Balance"])};
                accountRepoMock.Setup(a => a.Get(account.Id)).Returns(account);
            }
            
            _sut = new AccountsController(accountRepoMock.Object);
        }
        
        [When(@"I ask for details of account with id (.*)")]
        public void WhenIAskForDetailsOfAccountWithId(int accountId)
        {
            _result = _sut.Details(accountId) as ViewResult;
        }
        
        [Then(@"I should get account with id (.*) and balance (.*)")]
        public void ThenIShouldGetAccountWithBalance(int accountId, decimal balance)
        {
            Assert.IsNotNull(_result);
            var actual = _result.Model as Account;

            Assert.IsNotNull(actual);
            Assert.AreEqual(accountId,actual.Id);
            Assert.AreEqual(balance, actual.Balance);
        }
    }
}
