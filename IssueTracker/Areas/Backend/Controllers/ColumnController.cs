using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class ColumnController : AppCode.BaseController
    {
        
        // POST: Backend/Column/Create
        [HttpPost]
        public ActionResult Create(Column model)
        {

            try
            {
                this.oIssueTrackerUnitOfWork.ColumnRepository.Save(model);

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

    }
}