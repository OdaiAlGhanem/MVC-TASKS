using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task_mvc_5_2_2023.Models;

namespace task_mvc_5_2_2023.Controllers
{
    public class TaskEmployeesController : Controller
    {
        private odaiEntities2 db = new odaiEntities2();

        // GET: TaskEmployees
        public ActionResult Index(string searchBy , string search )
        {
            {
                if (searchBy == "Gender")
                {
                    return View(db.TaskEmployees.Where(x => x.Gender.ToString() == "True" && search == "male" || x.Gender.ToString() == "False" && search == "female" ||  search == null).ToList());
                }
                else if(searchBy == "First Name")
                {
                    return View(db.TaskEmployees.Where(x => x.First_Name.StartsWith(search) || search == null).ToList());

                }
              else if(searchBy == "Last Name")
                {
                    return View(db.TaskEmployees.Where(x => x.Last_Name.StartsWith(search) || search == null).ToList());
                }
              else
                {
                    return View(db.TaskEmployees.Where(x => x.Email.StartsWith(search) || search == null).ToList());
                }
            }
        }
        public PartialViewResult lastOrder()
        {
            var order = db.orders.OrderByDescending(o => o.order_date).First();
            return PartialView("_oneOrder", order);
        }

        // GET: TaskEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender")] TaskEmployee taskEmployee,HttpPostedFileBase UploadFile ,HttpPostedFileBase CVUpload)
        {
            if (ModelState.IsValid)
            {
                if(UploadFile.ContentLength>0)

                {
                    string ima =  Path.GetFileName(UploadFile.FileName);
                    string ima1 = Path.Combine(Server.MapPath("~/img"),ima);
                    UploadFile.SaveAs(ima1);
                    taskEmployee.Photo = ima;
                }

                if (CVUpload.ContentLength > 0)

                {
                    string ima = Path.GetFileName(CVUpload.FileName);
                    string ima1 = Path.Combine(Server.MapPath("~/CV"), ima);
                    CVUpload.SaveAs(ima1);
                    taskEmployee.CV = ima;
                }

                db.TaskEmployees.Add(taskEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskEmployee);
        }

        // GET: TaskEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender")] TaskEmployee taskEmployee, HttpPostedFileBase UploadFile, HttpPostedFileBase CVUpload , int? id )
        {
            if (ModelState.IsValid)

            {
                var odi = db.TaskEmployees.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (UploadFile != null)

                {
                    string ima = Path.GetFileName(UploadFile.FileName);
                    string ima1 = Path.Combine(Server.MapPath("~/img"), ima);
                   
                    UploadFile.SaveAs(ima1);
                    taskEmployee.Photo = ima;
                }
                else
                {
                    taskEmployee.Photo = odi.Photo;
                }

                if (CVUpload != null)

                {
                    string ima = Path.GetFileName(CVUpload.FileName);
                    string ima1 = Path.Combine(Server.MapPath("~/CV"), ima);
                    CVUpload.SaveAs(ima1);
                    taskEmployee.CV = ima;
                }
                else
                {
                    taskEmployee.CV = odi.CV;     
                }
                db.Entry(taskEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            db.TaskEmployees.Remove(taskEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      
    }
}
