using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banker.Domain.TDD.Infrastructure;
using Banker.Domain.TDD.Model;
using FakeItEasy;
using NUnit.Framework;

namespace Banker.Domain.TDD.Test
{
    [TestFixture]
    public class AccountServiceTest
    {
        public AccountServiceTest()
        {
            
        }
        //برمجة عملية سحب من حساب جاري
        //افترض وجود حساب لعميل
        //عندما اعطي رقم الحساب و القيمة
        //ثم اقوم بعملية السحب
        //********اجد الرصيد نقص بمقدار هذه القيمة*
        //*******يقوم النظام بتعديل رصيد الحساب في قاعدة البيانات*
        //*******ويقوم النظام بتسجيل حركة حساب بعملية السحب التي تمت
        [Test]
        public void Deduct_balance_by_withdrawn_amount()
        {
            var accountRepo = A.Fake<IAccountsRepository>();
            var transactionRepo = A.Fake<ITransactionRepository>();

            //افترض وجود حساب لعميل
            int accountId = 1;
            decimal amount = 500;
            var account = new Account(){Balance=1000};
            A.CallTo(() =>
                accountRepo.Get(1))
                .Returns(account);
            //عندما اعطي رقم الحساب و القيمة
            //ثم اقوم بعملية السحب
            //Execution
            var sut = new AccountantService(accountRepo, transactionRepo);
            var result = sut.Withdraw(accountId,amount);
            A.CallTo(() => accountRepo.Get(1)).MustHaveHappened(Repeated.AtLeast.Once);

            //يقوم النظام بتعديل رصيد الحساب في قاعدة البيانات
            A.CallTo(()=>accountRepo.Update(account)).MustHaveHappened(Repeated.AtLeast.Once);

            //اجد الرصيد نقص بمقدار هذه القيمة
            Assert.AreEqual(500,result.Balance);
        }

        [Test]
        public void Create_transaction_to_register_withdrawal_action()
        {
             var accountRepo = A.Fake<IAccountsRepository>();
            var transactionRepo = A.Fake<ITransactionRepository>();
            //افترض وجود حساب لعميل
            int accountId = 1;
            decimal amount = 500;
            
            //عندما اعطي رقم الحساب و القيمة
            //ثم اقوم بعملية السحب
            //Execution
            var sut = new AccountantService(accountRepo,transactionRepo);
            var result = sut.Withdraw(accountId,amount);
            //ويقوم النظام بتسجيل حركة حساب بعملية السحب التي تمت
            A.CallTo(() => transactionRepo.Create(accountId,amount)).MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}
