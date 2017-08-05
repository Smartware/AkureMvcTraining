using AkureTraining.Core.Context;
using AkureTraining.Core.Services;
using AkureTraining.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AkureTraining.Core.Controllers.Mvc
{
    public class HomeController : BaseMvcController
    {
        private readonly TransactionService _txnSvc;
        private readonly ContactService _cntctSvc;
        private readonly BaseAppService _baseAppSvc;
        private readonly MessagesServices _msgSvc;
        private readonly AccountServices _AccSvc;


        public HomeController(BaseAppService baseAppSvc, TransactionService txnSvc,
            ContactService cntctSvc, MessagesServices msgSvc, AccountServices AccSvc)
        {
            _baseAppSvc = baseAppSvc;
            _txnSvc = txnSvc;
            _cntctSvc = cntctSvc;
            _msgSvc = msgSvc;
            _AccSvc = AccSvc;
        }

        public PartialViewResult ProductList()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            //var counterData = _baseAppSvc.GetDashboardCounter(DateTime.Now).FirstOrDefault();

            //var vm = new DasboardViewModel()
            //{
            //    TotalContacts = counterData.TotalContacts,
            //    TodayTotalTransaction = counterData.TodayTotalTransaction,
            //    SmsUnitBalance = counterData.SmsUnitBalance,
            //    TotalmessageSent = counterData.TotalmessageSent
            //};

            // ViewBag.ProfileName = $"{User.Identity.Name} - " + $"{this.Country}";
            return View(new DasboardViewModel() );
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Home()
        {
            String message;
#if DEBUG
            message = "DEBUG MODE";
#elif MOCK
                   message = "DEBUG MODE";
#else
            mesage = "RELEASE MODE";
#endif
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}
