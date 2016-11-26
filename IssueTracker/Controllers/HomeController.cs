using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class HomeController : AppCode.BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}