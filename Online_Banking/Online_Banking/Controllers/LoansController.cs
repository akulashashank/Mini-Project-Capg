using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Online_Banking.Models;

namespace Online_Banking.Controllers
{
    public class LoansController : Controller
    {
        Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2();
        // GET: Loans
        public ActionResult Loan()
        {// Account_Master_174797_Project newUser = (Account_Master_174797_Project)from cust in db.Account_Master_174797_Project where cust.Email.Equals(Session["Email"]) select cust;
         // ViewBag.AccountID = newUser.Email;

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
        public ActionResult Loan(Models.Loan_174797_Project user)
        {
            if (Session["Email"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        using (var db = new Training_20Feb_MumbaiEntities2())
                        {

                            var newUser = db.Loan_174797_Project.Create();
                            newUser.AccountID = user.AccountID;
                            newUser.Email = user.Email;
                            newUser.TypeofLoan = user.TypeofLoan;
                            newUser.Loanammount = user.Loanammount;
                            newUser.DurationofLoan = user.DurationofLoan;

                            newUser.EMI = user.EMI;
                            newUser.Applicationstatus = "In Progress...";

                            db.Loan_174797_Project.Add(newUser);
                            db.SaveChanges();
                            ViewBag.Message = "Successfully applied for the laon";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Data is not correct");
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }
        public ActionResult Status(string SearchStringCustemail)
        {

            if (Session["Email"] != null)
            {

                return View(db.Loan_174797_Project.Where(x => x.Email.Contains(SearchStringCustemail)).ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }


    }
}