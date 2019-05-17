using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Banking.Models;
using Online_Banking.BusinessLayer;

namespace Online_Banking.Controllers
{
    public class BillPaysController : Controller
    {
        private Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();

        // GET: 
       
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                var billPays = db.BillPays.Include(b => b.Account_Master_174797_Project).Include(b => b.Payee);
                return View(billPays.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillPay billPay = db.BillPays.Find(id);
            if (billPay == null)
            {
                return HttpNotFound();
            }
            return View(billPay);
        }
        
        public ActionResult Create()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type");
            ViewBag.PayeeID = new SelectList(db.Payees, "PayeeID", "PayeeName");
            return View();
        }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillPayID,Account_No,PayeeID,Amount,ScheduleDate,Period,ModifyDate")] BillPay billPay)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    string email = Session["Email"].ToString();
                    var res = db.Account_Master_174797_Project.Where(a => a.Email.Equals(email)).First();
                    if (res.Balance > Convert.ToDouble(billPay.Amount))
                    {
                        res.Balance = res.Balance - Convert.ToDouble(billPay.Amount);
                        db.BillPays.Add(billPay);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message("", "InSufficient Balance");
                    }
                }
                else
                {
                    ViewBag.Message("", "Payment not done, please check gain");
                }

                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", billPay.Account_No);
                ViewBag.PayeeID = new SelectList(db.Payees, "PayeeID", "PayeeName", billPay.PayeeID);
                return View(billPay);
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
            BillPay billPay = db.BillPays.Find(id);
            if (billPay == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", billPay.Account_No);
            ViewBag.PayeeID = new SelectList(db.Payees, "PayeeID", "PayeeName", billPay.PayeeID);
            return View(billPay);
        }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillPayID,Account_No,PayeeID,Amount,ScheduleDate,Period,ModifyDate")] BillPay billPay)
        {

            if (Session["Email"] != null)
            {

                if (ModelState.IsValid)
            {
                db.Entry(billPay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", billPay.Account_No);
            ViewBag.PayeeID = new SelectList(db.Payees, "PayeeID", "PayeeName", billPay.PayeeID);
            return View(billPay);
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
            BillPay billPay = db.BillPays.Find(id);
            if (billPay == null)
            {
                return HttpNotFound();
            }
            return View(billPay);
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
                BillPay billPay = db.BillPays.Find(id);
            db.BillPays.Remove(billPay);
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
