using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServiceClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var serviceClient = new ServiceReference2.Service1Client();
            //var std = new ServiceReference2.Student() {
            //    Name = "Le Phuong Nam"
            //};
            //var result = serviceClient.GetStudentData(std);
            //ViewBag.Message = "Your student name: " + result.Id;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}