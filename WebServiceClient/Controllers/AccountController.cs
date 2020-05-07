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
            //ViewBag.message = "";
            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.message = message;
            //}
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(string code, string pass)
        {
            var message = "fail";
            ServiceReference2.Account account = serviceClient.GetAccount(code, pass);
            if (account != null)
            {
                message = "Hello " + account.Name;
            }
            ViewBag.Message = message;
            return RedirectToAction("getTransfer", account);
        }

        public ActionResult getTransfer(ServiceReference2.Account account)
        {
            ViewBag.Name = account.Name;
            ViewBag.Money = account.Money;
            ViewBag.Code = account.Code;
            return View();
        }

        public ActionResult postTransfer(string sCode, string rCode, double amount)
        {
            var message = serviceClient.TransferMoney(sCode, rCode, amount);
            return RedirectToAction("Index");
        }
    }
}
