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
    public class TransactionsController : Controller
    {
        private Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();


        public ActionResult Index(string searchStringCustemail, string searchStringAcctType)
        {
            if (Session["Email"] != null)
            {

                var AcctTypeLst = new List<string>();

                var AcctTypeQry = from a in db.Account_Master_174797_Project
                                  orderby a.Account_Type
                                  where (a.Email.Contains(searchStringCustemail))
                                  select a.Account_Type;
                AcctTypeLst.AddRange(AcctTypeQry.Distinct());
                ViewBag.acctType = new SelectList(AcctTypeLst);

                var transactions = from t in db.Transactions_174797_Project
                                   select t;

                if (!String.IsNullOrEmpty(searchStringCustemail))
                {
                    transactions = transactions.Where(s => s.Account_Master_174797_Project.Email.Contains(searchStringCustemail));
                }

                if (string.IsNullOrEmpty(searchStringAcctType))
                    return View(transactions);
                else
                {
                    return View(transactions.Where(x => x.Account_Master_174797_Project.Account_Type == searchStringAcctType));
                }

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
            Transactions_174797_Project transactions_174797_Project = db.Transactions_174797_Project.Find(id);
            if (transactions_174797_Project == null)
            {
                return HttpNotFound();
            }
            return View(transactions_174797_Project);
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
