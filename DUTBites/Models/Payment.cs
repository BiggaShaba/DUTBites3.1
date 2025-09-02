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
        public int paymentID {get;set;}
        public int orderID { get;set;}
        [ForeignKey("orderID")]
        public Order order { get; set;}
        public int userID { get;set;}
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