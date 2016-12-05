using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class ManagerController : AppCode.BaseController
    {
        // GET: Backend/Home
        public ActionResult Index()
        {
            ViewData["Teams"] = this.oIssueTrackerUnitOfWork.TeamRepository.Select().ToList<Team>();
            ViewData["Projects"] = this.oIssueTrackerUnitOfWork.ProjectRepository.Select(null, "Team").ToList<Project>();
            ViewData["States"] = this.oIssueTrackerUnitOfWork.StateRepository.Select().ToList<State>();
            ViewData["Types"] = this.oIssueTrackerUnitOfWork.TypeRepository.Select().ToList<Models.Type>();
            ViewData["Priorities"] = this.oIssueTrackerUnitOfWork.PriorityRepository.Select().ToList<Priority>();

            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(Team oTeam)
        {
            try
            {
                this.oIssueTrackerUnitOfWork.TeamRepository.Save(oTeam);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = oTeam;
                    this.oResultData.Message = "Team Create Successful.";
                    return Json(oResultData);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors());
            }
            catch (Exception ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = oIssueTrackerUnitOfWork.GetValidationErrors();
                return Json(oResultData);
            }
        }
    }
}