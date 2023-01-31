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
        public ActionResult Default()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Files/Juice.jpg"));
            return File(fileBytes, "~/Files/jpg", "~/Files/juice.jpg");
        }

        public ActionResult AboutUs()
        {
            string html = "<a href='" + Url.Action("Default", "Default") + "'>" +
                            "<img src='../Files/juice.jpg' height='200' width='200' alt='Image to download' />" +
                          "</a>" +
                          "<br />" +
                          "This is the About Us page.";
            return Content(html);
        }

        public ActionResult ContactUs()
        {
            string html = "<a href='" + Url.Action("Default", "Default") + "'>" +
                            "<img src='~/image/juice.jpg' height='200' width='200' alt='Image to download' />" +
                          "</a>" +
                          "<br />" +
                          "This is the Contact Us page.";
            return Content(html);
        }
    }
}