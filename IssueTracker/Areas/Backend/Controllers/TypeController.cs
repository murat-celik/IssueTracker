using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class TypeController : AppCode.BaseController
    {
        // POST: Backend/Type/Create
        [HttpPost]
        public ActionResult Create(Models.Type model)
        {

            try
            {
                this.oIssueTrackerUnitOfWork.TypeRepository.Save(model);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = model;
                    this.oResultData.Message = "State Create Successful.";
                    return Json(oResultData);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState));
            }
            catch (Exception ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = oIssueTrackerUnitOfWork.GetValidationErrors(ViewData.ModelState);
                return Json(oResultData);

            }
        }

        //POST: Backend/Type/GetTypes
        [HttpPost]
        public ActionResult GetTypes()
        {
            this.oResultData.Data = oIssueTrackerUnitOfWork.TypeRepository.Select().ToList<Models.Type>();
            this.oResultData.Status = AppCode.StatusEnum.Active;
            this.oResultData.Message = "Load Types";

            return Json(oResultData, JsonRequestBehavior.AllowGet);
        }
    }
}