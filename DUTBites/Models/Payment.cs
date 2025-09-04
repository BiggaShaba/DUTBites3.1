using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DUTBites.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID {get;set;}
        public int OrderID { get;set;} // Add this property
        public virtual Order Order { get; set; }
        public int UserID { get;set;}
        public User User { get; set;}
        public decimal amount {get;set;}
        public PaymentMethod method { get;set;}
        public PaymentStatus status {get;set;}
        public DateTime paidAt {get;set;}

    }
    public enum PaymentMethod
    {
        Card,
        Wallet,
        Cash,
    }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
    }
}