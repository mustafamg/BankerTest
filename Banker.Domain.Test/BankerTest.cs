using FakeItEasy;
using NUnit.Framework;

namespace Banker.Domain.Test
{
    [TestFixture]
    public class BankerTest
    {
        [Test]
        public void Should_Increase_AccountBalance_After_Deposit()
        {
            //تجهيز
            var accRepoFake = A.Fake<IAccountsRepository>();
            A.CallTo(() => accRepoFake.Get(1)).Returns(
                new Account()
                {
                    Balance = 500
                });

            var transRepoFake = A.Fake<ITransactionsRepository>();
            var sut = new AccountantService(accRepoFake,transRepoFake);
            //تنفيذ
            var result = sut.Deposit(1, 1000);
            //تحقق
            Assert.That(result.Balance,Is.EqualTo(1500));

        }

        [Test]
        public void Should_Update_AccountBalance_After_Deposit()
        {
             //تجهيز
            var accRepoFake = A.Fake<IAccountsRepository>();
            var account = new Account();
            A.CallTo(() => 
                accRepoFake.Get(1))
                .Returns(account);

            var transRepoFake = A.Fake<ITransactionsRepository>();
            var sut = new AccountantService(accRepoFake,transRepoFake);
            //تنفيذ
            var result = sut.Deposit(1, 1000);
            //تحقق
            A.CallTo(() =>
               accRepoFake.Update(account)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Should_Create_Transaction_After_Deposit()
        {
            //تجهيز
            var accRepoFake = A.Fake<IAccountsRepository>();
            var transRepoFake = A.Fake<ITransactionsRepository>();
            var sut = new AccountantService(accRepoFake, transRepoFake);
            //تنفيذ
            var result = sut.Deposit(1, 1000);
            //تحقق
            A.CallTo(() =>
               transRepoFake.Create(1,1000)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
