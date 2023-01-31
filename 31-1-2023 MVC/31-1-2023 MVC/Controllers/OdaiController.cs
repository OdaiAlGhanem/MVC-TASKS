using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31_1_2023_MVC.Controllers
{
    public class OdaiController : Controller
    {
        // GET: Odai
        public string FullName()
        {

            return "ODAIALGHANEM";
        }
        public int phoneNumber()
        {

            return 0799995128;
        }
        public double Age()
        {
            return 29.5;
        }
    }
}