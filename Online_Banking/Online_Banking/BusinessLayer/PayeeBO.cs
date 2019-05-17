using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Banking.Models;

namespace Online_Banking.BusinessLayer
{
    public class PayeeBO
    {
        internal PayeeBO()
        {
        }


        public List<Payee> GetAll()
        {
            try
            {
                using (Training_20Feb_MumbaiEntities2 db = new Training_20Feb_MumbaiEntities2())
                {
                    return db.Payees.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}