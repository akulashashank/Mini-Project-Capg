//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Banking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BillPay
    {
        [Required(ErrorMessage = "Please Enter BillID")]
        public int BillPayID { get; set; }
        [Required(ErrorMessage = "Please Enter Account number")]
        public long Account_No { get; set; }
        [Required(ErrorMessage = "Please Enter Your payee ID")]
        public int PayeeID { get; set; }
        [Required(ErrorMessage = "Please Enter the amount you want to send")]
        public decimal Amount { get; set; }
        [Display(Name = "ScheduleDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ScheduleDate { get; set; }
        [Required(ErrorMessage = "Please Enter Period")]
        public string Period { get; set; }
  
        public string Status { get; set; }
        [Display(Name = "ModifyDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ModifyDate { get; set; }
    
        public virtual Account_Master_174797_Project Account_Master_174797_Project { get; set; }
        public virtual Payee Payee { get; set; }
    }
}
