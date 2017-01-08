using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class IssueController : AppCode.BaseController
    {
        // GET: Backend/Issue
        public ActionResult Index()
        {
            return View();
        }

        // POST: Backend/Issue/Create
        [HttpPost]
        public ActionResult Create(Issue model)
        {
            try
            {
                this.oIssueTrackerUnitOfWork.IssueRepository.Save(model);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = model;
                    this.oResultData.Message = "Issue Create Successful.";
                    return Json(oResultData);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState));
            }
            catch (Exception Ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = Ex.Message;
                return Json(oResultData);

            }
        }

        // POST: Backend/Issue/ChangeColumn
        [HttpPost]
        public ActionResult ChangeColumn(int IssueID, int ColumnID)
        {

            try
            {
                Issue Model = this.oIssueTrackerUnitOfWork.IssueRepository.FindById(IssueID);
                Model.ColumnID = ColumnID;

                this.oIssueTrackerUnitOfWork.IssueRepository.Save(Model);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    Model.Column = oIssueTrackerUnitOfWork.ColumnRepository.FindById(ColumnID, "State");
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = Model.Column.State.Name;
                    this.oResultData.Message = "Issue State Changed";
                    return Json(oResultData, JsonRequestBehavior.AllowGet);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState));
            }
            catch (Exception Ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = Ex.Message;
                return Json(oResultData);

            }
        }

        // GET: Backend/Issue/Details/5
        public ActionResult Details(int id)
        {
            Issue Model = this.oIssueTrackerUnitOfWork.IssueRepository.FindById(id, "UserCreated", "UserUpdated", "Board", "Project", "Collobrator", "Priority", "Type", "Column","Column.State", "Watchers", "Watchers.Collobrator", "Comments", "Comments.Collobrator","IssueTags", "IssueTags.Tag");

            ViewData["States"] = this.oIssueTrackerUnitOfWork.StateRepository.Select().ToList<State>();

            return View(Model);
        }

    }
}