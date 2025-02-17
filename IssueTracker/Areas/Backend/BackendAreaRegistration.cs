﻿using System.Web.Mvc;

namespace IssueTracker.Areas.Backend
{
    public class BackendAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Backend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Backend_default",
                "Backend/{controller}/{action}/{id}",
                defaults: new { controller = "Manager", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}