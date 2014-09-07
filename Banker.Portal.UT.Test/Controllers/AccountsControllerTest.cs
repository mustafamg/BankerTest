using System.Collections.Generic;
using System.Web.Mvc;
using Banker.Domain;
using Banker.Domain.TDD.Model;
using Banker.Portal.Controllers;
using Moq;
using NUnit.Framework;
using Banker.Domain.TDD.Infrastructure;

namespace Banker.Portal.UT.Test.Controllers
{
    [TestFixture]
    public class AccountsControllerTest
    {
        [Test]
        public void Accounts_Home_Page_Will_Redirect_To_List_Page()
        {
            //Given i'm on Accounts Home Page
            //التجهيز
            var sut = new AccountsController();
           
            //Then I should be redirected to Accounts/List Page
            //التنفيذ
            var result = sut.Index() as RedirectToRouteResult;
            //التحقق
            Assert.IsNotNull(result);
            Assert.AreEqual("List",result.RouteValues["action"]);
        }

        [Test]
        public void Accounts_list_page_Shows_List_Of_Accouts()
        {
            //Given I have the following accounts:
            //التجهيز
            var accountRepoMock = new Mock<IAccountsRepository>();
            //AccountID |Balance
            //1         |100
            //9         |900
            //15        |700
            accountRepoMock.Setup(a => a.List()).Returns(new List<Account>()
            {
                new Account() {Id = 1, Balance = 100},
                new Account() {Id = 9, Balance = 900},
                new Account() {Id = 15, Balance = 700}
            });
            var sut = new AccountsController(accountRepoMock.Object);
            //When I visite account list
            var result = sut.List() as ViewResult;
            //Then I should have view with model that has the following list
            Assert.IsNotNull(result);
            //AccountID |Balance
            //1         |100
            //9         |900
            //15        |700
            List<Account> list = result.Model as List<Account>;
            Assert.IsNotNull(list);
            Assert.IsTrue(AreEqualAccounts(1,100,list[0]));
            Assert.IsTrue(AreEqualAccounts(9, 900, list[1]));
            Assert.IsTrue(AreEqualAccounts(15, 700, list[2]));
        }

        private bool AreEqualAccounts(int id, decimal balance, Account account)
        {
            return id == account.Id && balance == account.Balance;
        }

        [Test]
        public void Accont_Details_based_on_sent_id()
        {
            //Given I have the following accounts:
            //التجهيز
            var accountRepoMock = new Mock<IAccountsRepository>();
            //AccountID |Balance
            //1         |100
            //9         |900
            //15        |700
            accountRepoMock.Setup(a => a.Get(9)).Returns(new Account()
            {Id = 9, Balance = 900});
            var sut = new AccountsController(accountRepoMock.Object);
            //When I ask for details of account with id 9
            var result = sut.Details(9) as ViewResult;
            //Then I should get account with balance 900

            var account = result.Model as Account;
            Assert.IsNotNull(account);
            Assert.IsTrue(AreEqualAccounts(9, 900, account));
        }
    }
}
