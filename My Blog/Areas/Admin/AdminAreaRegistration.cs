﻿using System.Web.Mvc;

namespace My_Blog.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "PostManagement", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"My_Blog.Areas.Admin.Controllers"}
            );
        }
    }
}