using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31_1_2023_MVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return Content(

                    "\r\n<a href=\"img.jpg\" download>" +
                    "\r\n  <img src=\"img.jpg\" alt=\"W3Schools\" " +
                    "width=\"104\" height=\"142\">\r\n</a>");
        }
        public string About()
        {
            return "welcome coach";
        }
        public ActionResult Contact()
        {
            return Content(
                "\r\n<h2>HTML Forms</h2>\r\n\r\n<form action=\"/action_page.php\">\r\n  <label for=\"fname\">First name:</label><br>\r\n  <input type=\"text\" id=\"fname\" name=\"fname\" value=\"John\"><br>\r\n  <label for=\"lname\">Last name:</label><br>\r\n  <input type=\"text\" id=\"lname\" name=\"lname\" value=\"Doe\"><br><br>\r\n  <input type=\"submit\" value=\"Submit\">\r\n</form> \r\n\r\n<p>If you click the \"Submit\" button, the form-data will be sent to a page called \"/action_page.php\".</p>\r\n"
                );
        }
    }
}