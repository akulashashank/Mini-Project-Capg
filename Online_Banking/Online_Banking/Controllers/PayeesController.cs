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
    public class PayeesController : Controller
    {
        private Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();

        // GET: Payees
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                return View(db.Payees.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        public ActionResult Details(int? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Payee payee = db.Payees.Find(id);
                if (payee == null)
                {
                    return HttpNotFound();
                }
                return View(payee);
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
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayeeID,PayeeName,Address,City,State,PostCode,Phone,ModifyDate")] Payee payee)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Payees.Add(payee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(payee);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        public ActionResult Edit(int? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Payee payee = db.Payees.Find(id);
                if (payee == null)
                {
                    return HttpNotFound();
                }
                return View(payee);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayeeID,PayeeName,Address,City,State,PostCode,Phone,ModifyDate")] Payee payee)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(payee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(payee);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        public ActionResult Delete(int? id)
        {
            if (Session["Email"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Payee payee = db.Payees.Find(id);
                if (payee == null)
                {
                    return HttpNotFound();
                }
                return View(payee);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Email"] != null)
            {
                Payee payee = db.Payees.Find(id);
                db.Payees.Remove(payee);
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
