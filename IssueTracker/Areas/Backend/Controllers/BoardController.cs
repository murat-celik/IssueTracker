using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class BoardController : AppCode.BaseController
    {
        // GET: Backend/Board
        public ActionResult Index()
        {
            return View();
        }

        // POST: Backend/Board/Create
        [HttpPost]
        public ActionResult Create(Board model)
        {

            try
            {
                this.oIssueTrackerUnitOfWork.BoardRepository.Save(model);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = model;
                    this.oResultData.Message = "Board Create Successful.";
                    return Json(oResultData);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState));
            }
            catch (Exception ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = ex.Message;
                return Json(oResultData);

            }
        }

        // GET: Backend/Team/Details/5
        public ActionResult Details(int id)
        {
            Board model = this.oIssueTrackerUnitOfWork.BoardRepository.FindById(id, "Project", "Project.Team", "Columns", "Columns.State", "Columns.Issues", "Columns.Issues.IssueTags.Tag", "Project.Team.TeamCollobrators.Collobrator.User");
          

            ViewData["Types"] = this.oIssueTrackerUnitOfWork.TypeRepository.Select().ToList<Models.Type>();
            ViewData["Priorities"] = this.oIssueTrackerUnitOfWork.PriorityRepository.Select().ToList<Priority>();

            return View(model);
        }
    }
}