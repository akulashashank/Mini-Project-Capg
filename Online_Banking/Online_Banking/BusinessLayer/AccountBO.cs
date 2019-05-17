using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Banking.Models;
namespace Online_Banking.BusinessLayer
{
    public class AccountBO
    {
        internal AccountBO()
        {
        }
        public Account_Master_174797_Project getById(int accountNo)
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.Account_Master_174797_Project.SingleOrDefault(a => a.Account_No == accountNo);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Account_Master_174797_Project> getAll()
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.Account_Master_174797_Project.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public List<Account_Master_174797_Project> getByAccount_No(int accountno)
        //{
        //    try
        //    {
        //        using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
        //        {
        //            return db.Account_Master_174797_Project.Where(a => a.Account_No == accountno).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public string getAccountTypeByNo(int accountNumber)
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    string accountType = (from t in db.Account_Master_174797_Project
                                          where t.Account_No == accountNumber
                                          select t.Account_Type).FirstOrDefault();
                    return accountType;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}