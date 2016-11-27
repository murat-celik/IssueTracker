using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.AppCode
{
    public class BaseController : Controller
    {
        public IssueTracker.AppCode.IssueTrackerFacede oFacade = new AppCode.IssueTrackerFacede();

        protected override void Initialize(System.Web.Routing.RequestContext RequestContext)
        {
            base.Initialize(RequestContext);
        }

        
        protected override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            base.OnActionExecuting(FilterContext);
        }

    }
}