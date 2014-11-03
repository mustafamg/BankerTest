using System.Net;
using System.Web.Mvc;
using Banker.Domain.TDD.Infrastructure;
using Banker.Domain.TDD.Model;
using Banker.Domain.TDD.Repositories;

namespace Banker.Portal.Controllers
{
    public class AccountsController : Controller
    {
        readonly IAccountsRepository _accountsRepo;
        public AccountsController()
        {
            _accountsRepo = new AccountsRepository();
        }

        public AccountsController(IAccountsRepository repository)
        {
            _accountsRepo = repository;
        }
        // GET: Accounts
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var model = _accountsRepo.List();
            return View(model);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = new Account();//_accountsRepo.Get(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
