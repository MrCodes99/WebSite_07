﻿using System.Web;
using System.Web.Mvc;

namespace WebSite_Semana07
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
