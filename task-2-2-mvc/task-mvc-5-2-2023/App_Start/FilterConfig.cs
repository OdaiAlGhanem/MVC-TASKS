﻿using System.Web;
using System.Web.Mvc;

namespace task_mvc_5_2_2023
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
