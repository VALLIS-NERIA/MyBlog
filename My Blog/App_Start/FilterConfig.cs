﻿using System.Web;
using System.Web.Mvc;

namespace My_Blog {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
