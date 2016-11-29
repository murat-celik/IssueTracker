using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IssueTracker.Models;
using IssueTracker.UnitOfWork;

namespace IssueTracker.Controllers
{
    public class HomeController : AppCode.BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //Team oTeam = new Team();
            //oTeam.Name = "Hasan";
            //oTeam.Desription = "Ali";
            //this.oIssueTrackerUnitOfWork.TeamRepository.Insert(oTeam);
            //this.oIssueTrackerUnitOfWork.Save();

            //var Teams =  this.oIssueTrackerUnitOfWork.TeamRepository.Select(null, new List<string> { "UserUpdated", "UserCreated" }).ToList();
            
            return View();
        }

        public ActionResult me()
        {
            var Teams = this.oIssueTrackerUnitOfWork.TeamRepository.Select(null, new List<string> { "UserUpdated", "UserCreated" }).ToList();

            return Json(Teams);
        }
    }
}