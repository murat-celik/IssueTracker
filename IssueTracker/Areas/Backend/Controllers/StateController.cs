using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class StateController : AppCode.BaseController
    {

        // POST: Backend/Project/Create
        [HttpPost]
        public ActionResult Create(State oState)
        {

            try
            {
                this.oIssueTrackerUnitOfWork.StateRepository.Save(oState);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = oState;
                    this.oResultData.Message = "State Create Successful.";
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