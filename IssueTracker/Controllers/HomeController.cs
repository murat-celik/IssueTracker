using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class HomeController : AppCode.BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //Team oTeam = new Team();
            //oTeam.Name = "Şevkey";
            //oTeam.Desription = "Tekin";
            //this.oFacade.Model<Team>().Save(oTeam);

            var Teams = this.oFacade.Model<Team>().Select(null, new List<string> { "UserUpdated", "UserCreated" }).ToList();
            
            return View(Teams);
        }

        public ActionResult  me()
        {
            var Teams = this.oFacade.Model<Team>().Select(null, new List<string> { "UserUpdated", "UserCreated" }).ToList();

            return Json(Teams);
        }
    }
}