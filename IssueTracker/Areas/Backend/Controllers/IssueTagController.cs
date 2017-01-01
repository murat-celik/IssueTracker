using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class IssueTagController : AppCode.BaseController
    {

        // POST: Backend/IssueTag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                oIssueTrackerUnitOfWork.IssueTagRepository.Delete(id);
                this.oResultData.Status = AppCode.StatusEnum.Active;
                this.oResultData.Message = "Issue Tag Deleted";
                return Json(oResultData);
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