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
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(Team oTeam)
        {
            try
            {
                oTeam.Name = Request.Form.Get("Name");
                oTeam.Description = null;
                if (ModelState.IsValidField("Description"))
                {

                }
                // oTeam.Description = collection.Get("Description");

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