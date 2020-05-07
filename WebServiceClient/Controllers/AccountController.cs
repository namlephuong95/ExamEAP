using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServiceClient.Controllers
{
    public class AccountController : Controller
    {
        private ServiceReference2.Service1Client serviceClient = new ServiceReference2.Service1Client();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string code, string pass)
        {
            ServiceReference2.Account account = serviceClient.GetAccount(code, pass);
            ViewBag.Name = account.Name;
            ViewBag.Code = account.Code;
            ViewBag.Money = account.Money;
            return View();
        }

        [HttpGet]
        public ActionResult Transfer(string sCode, string rCode, double amount)
        {
            var message = serviceClient.TransferMoney(sCode, rCode, amount);
            ViewBag.Message = message;
            return View();
        }
    }
}