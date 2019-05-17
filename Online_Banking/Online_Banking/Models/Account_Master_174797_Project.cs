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

    public partial class Account_Master_174797_Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account_Master_174797_Project()
        {
            this.Loan_174797_Project = new HashSet<Loan_174797_Project>();
            this.Transactions_174797_Project = new HashSet<Transactions_174797_Project>();
            this.BillPays = new HashSet<BillPay>();
            this.Check_174797_Project = new HashSet<Check_174797_Project>();
        }
        [Required(ErrorMessage = "Please Enter  Account Number")]
        public long Account_No { get; set; }
        [Required(ErrorMessage = "Please Enter Account type")]
        public string Account_Type { get; set; }
        [Required(ErrorMessage = "Please Enter user name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide your password")]
        public string PassWord { get; set; }
        public Nullable<double> Balance { get; set; }
        [Display(Name = "Apply_Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Opening_Date { get; set; }
        [Required(ErrorMessage = "Please Enter your Email ID")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter your address")]
        public string HouseAddress { get; set; }
        [Required(ErrorMessage = "Please provide your PAN number")]
        public string Pancard_no { get; set; }
        [Required(ErrorMessage = "Please Enter Account mode")]
        public string AccountaccessMode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan_174797_Project> Loan_174797_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions_174797_Project> Transactions_174797_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillPay> BillPays { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check_174797_Project> Check_174797_Project { get; set; }
    }
}