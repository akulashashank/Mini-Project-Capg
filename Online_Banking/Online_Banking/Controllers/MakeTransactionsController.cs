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
    public class MakeTransactionsController : Controller
    {
        private Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();

        // GET: MakeTransactions
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                var transactions_174797_Project = db.Transactions_174797_Project.Include(t => t.Account_Master_174797_Project);
                return View(transactions_174797_Project.ToList());
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
                Transactions_174797_Project transactions_174797_Project = db.Transactions_174797_Project.Find(id);
                if (transactions_174797_Project == null)
                {
                    return HttpNotFound();
                }
                return View(transactions_174797_Project);
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
                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Transaction_ID,DateofTransaction,TypeofTransaction,Account_No,Amount")] Transactions_174797_Project transactions_174797_Project)
        {
            if (Session["Email"] != null)
            {

                if (ModelState.IsValid)
                {
                    string email = Session["Email"].ToString();
                    var res = db.Account_Master_174797_Project.Where(a => a.Email.Equals(email)).First();
                    if (transactions_174797_Project.TypeofTransaction == "Withdraw")
                    {
                        if (res.Balance > Convert.ToDouble(transactions_174797_Project.Amount))
                        {
                            res.Balance = res.Balance - Convert.ToDouble(transactions_174797_Project.Amount);
                            db.Transactions_174797_Project.Add(transactions_174797_Project);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message("", "InSufficient Balance");
                        }
                    }
                    else if (transactions_174797_Project.TypeofTransaction == "Deposit" || transactions_174797_Project.TypeofTransaction == "DD")
                    {
                        res.Balance = res.Balance + Convert.ToDouble(transactions_174797_Project.Amount);
                        db.Transactions_174797_Project.Add(transactions_174797_Project);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", transactions_174797_Project.Account_No);
                return View(transactions_174797_Project);
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
                Transactions_174797_Project transactions_174797_Project = db.Transactions_174797_Project.Find(id);
                if (transactions_174797_Project == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", transactions_174797_Project.Account_No);
                return View(transactions_174797_Project);
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Transaction_ID,DateofTransaction,TypeofTransaction,Account_No,Amount")] Transactions_174797_Project transactions_174797_Project)
        {
            if (Session["Email"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transactions_174797_Project).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Account_No = new SelectList(db.Account_Master_174797_Project, "Account_No", "Account_Type", transactions_174797_Project.Account_No);
                return View(transactions_174797_Project);
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
                Transactions_174797_Project transactions_174797_Project = db.Transactions_174797_Project.Find(id);
                if (transactions_174797_Project == null)
                {
                    return HttpNotFound();
                }
                return View(transactions_174797_Project);
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
                Transactions_174797_Project transactions_174797_Project = db.Transactions_174797_Project.Find(id);
                db.Transactions_174797_Project.Remove(transactions_174797_Project);
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
