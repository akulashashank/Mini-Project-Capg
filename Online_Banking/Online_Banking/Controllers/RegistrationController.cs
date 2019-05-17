using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Online_Banking.Models;


namespace Online_Banking.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            
                return View();
            }
        [HttpGet]
        public ActionResult LogIn()
        {
            
                return View();
            }
            
      

        [HttpPost]
        public ActionResult LogIn(Models.Account_Master_174797_Project userr)

        {
                //if (ModelState.IsValid)  
                //{  
                if (IsValid(userr.Email, userr.PassWord))
                {
                    Session["Email"] = userr.Email;
                    FormsAuthentication.SetAuthCookie(userr.Email, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong.");
                }
                return View(userr);
            }
            
        
        [HttpGet]
        public ActionResult Register()
        {
           
                return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Account_Master_174797_Project user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new Training_20Feb_MumbaiEntities2())
                    {
                        
                        var newUser = db.Account_Master_174797_Project.Create();
                        newUser.Account_No =user.Account_No;
                        newUser.Account_Type = user.Account_Type;
                        newUser.Username = user.Username;
                        newUser.PassWord = user.PassWord;
                        //newUser.Balance = user.Balance;
                        newUser.Balance = 10000;
                        newUser.Opening_Date = user.Opening_Date;
                        newUser.Email = user.Email;
                        newUser.HouseAddress = user.HouseAddress;
                        newUser.Pancard_no = user.Pancard_no;
                        newUser.AccountaccessMode = user.AccountaccessMode;
                        db.Account_Master_174797_Project.Add(newUser);
                        db.SaveChanges();
                        return RedirectToAction("LogIn", "Registration");
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
       
        public ActionResult LogOut()
        {
            Session.Clear();
            
            return RedirectToAction("LogIn");
        }
        private bool IsValid(string email, string password)
        {

            bool IsValid = false;

            using (var db = new Training_20Feb_MumbaiEntities2())
            {
                var user = db.Account_Master_174797_Project.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if (user.PassWord == password)
                    {
                        IsValid = true;

                    }
                }
                return IsValid;
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string  Email, string PassWord)
        {
            Training_20Feb_MumbaiEntities2 tr = new Training_20Feb_MumbaiEntities2();
            var details = tr.Account_Master_174797_Project.Single(u => u.Email == Email);
            if (details != null)
            {
                details.PassWord = PassWord;
                if (TryUpdateModel(details))
                {
                    tr.SaveChanges();
                    return RedirectToAction("LogIn");
                }
            }
            return View();
        }

        
    }
}