using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Banking.Models;

namespace Online_Banking.Controllers
{
    public class CheckBookController : Controller
    {
        private Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();

        // GET: CheckBook
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                var check_174797_Project = db.Check_174797_Project.Include(c => c.Account_Master_174797_Project);
                return View(check_174797_Project.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }



        public ActionResult Details(long? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Check_174797_Project check_174797_Project = db.Check_174797_Project.Find(id);
                if (check_174797_Project == null)
                {
                    return HttpNotFound();
                }
                return View(check_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        public ActionResult Create()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Account_no = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type");
                ViewBag.Message = "Request for check book done Successfully";
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Check_ID,Account_no,phoneno,address")] Check_174797_Project check_174797_Project)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Check_174797_Project.Add(check_174797_Project);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                ViewBag.Account_no = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", check_174797_Project.Account_no);

                return View(check_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        public ActionResult Edit(long? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Check_174797_Project check_174797_Project = db.Check_174797_Project.Find(id);
                if (check_174797_Project == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Account_no = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", check_174797_Project.Account_no);
                return View(check_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Check_ID,Account_no,phoneno,address")] Check_174797_Project check_174797_Project)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(check_174797_Project).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Account_no = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", check_174797_Project.Account_no);
                return View(check_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        public ActionResult Delete(long? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Check_174797_Project check_174797_Project = db.Check_174797_Project.Find(id);
                if (check_174797_Project == null)
                {
                    return HttpNotFound();
                }
                return View(check_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (Session["Email"] != null)
            {
                Check_174797_Project check_174797_Project = db.Check_174797_Project.Find(id);
                db.Check_174797_Project.Remove(check_174797_Project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
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
