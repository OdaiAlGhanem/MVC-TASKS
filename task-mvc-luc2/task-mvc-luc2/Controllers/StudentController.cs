using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task_mvc_luc2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Student()
        {

            List<Models.Student> student = new List<Models.Student>();
            student.Add(new Models.Student() { Id = 1, Name = "odai", Major = "PlantProduction", Faculity = "Agricultural", });
            student.Add(new Models.Student() { Id = 2, Name = "ali", Major = "SoftwareEngineering", Faculity = "IT", });
            student.Add(new Models.Student() { Id = 2, Name = "issa", Major = "CivialEngineering", Faculity = "Engineering", });

            return View(student);
        }
    }
}