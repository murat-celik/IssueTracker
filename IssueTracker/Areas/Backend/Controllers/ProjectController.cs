using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class ProjectController : AppCode.BaseController
    {
        // GET: Backend/Project
        public ActionResult Index()
        {

            return View();
        }

        // POST: Backend/Project/Create
        [HttpPost]
        public ActionResult Create(Project oProject)
        {

            try
            {
                this.oIssueTrackerUnitOfWork.ProjectRepository.Save(oProject);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = oProject;
                    this.oResultData.Message = "Project Create Successful.";

                    if (Request.Form.Get("ajax")!=null)
                    {
                        return Json(oResultData);
                    }

                    return RedirectToAction("Index");
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState));
            }
            catch (Exception ex)
            {
                if (Request.Form.Get("ajax") != null)
                {
                    this.oResultData.Status = AppCode.StatusEnum.Pasive;
                    this.oResultData.Message = oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState);
                    return Json(oResultData);
                }

                return View();
            }
        }

        // GET: Backend/Team/Details/5
        public ActionResult Details(int id)
        {
            Project Model = this.oIssueTrackerUnitOfWork.ProjectRepository.FindById(id, "UserCreated", "UserUpdated", "Team", "Tags", "Boards", "Boards.Columns");

            ViewData["States"] = this.oIssueTrackerUnitOfWork.StateRepository.Select().ToList<State>();

            return View(Model);
        }
    }
}