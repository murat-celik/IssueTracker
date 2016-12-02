using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class BoardController : AppCode.BaseController
    {
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }
    }
}