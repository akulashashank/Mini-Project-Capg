using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Banking.Models;

namespace Online_Banking.BusinessLayer
{
    public class BPayBO
    {


        public BillPay GetById(int billPayId)
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.BillPays.SingleOrDefault(c => c.BillPayID == billPayId);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BillPay> GetAll()
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.BillPays.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BillPay> GetAllIncludePayee()
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.BillPays.Include("Payee").ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BillPay> GetAllIncludePayeeById(int id)
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.BillPays.Include("Payee").Include("Account_Master_174797_Project").Where(b => b.Account_Master_174797_Project.Account_No == id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BillPay> GetActive()
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    var query = from t in db.BillPays
                                where t.ScheduleDate > DateTime.Now && t.Status == "Y"
                                select t;
                    return query.ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BillPay CreateBillPay(int accountNo, int payeeId, decimal amount, DateTime scheduleDate, string period)
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    BillPay billPay = new BillPay();
                    billPay.Account_No = accountNo;
                    billPay.PayeeID = payeeId;
                    billPay.Amount = amount;
                    billPay.ScheduleDate = scheduleDate;
                    billPay.Period = period;
                    billPay.Status = "Y";
                    billPay.ModifyDate = DateTime.Now;
                    db.BillPays.Add(billPay);
                    db.SaveChanges();
                    return billPay;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}