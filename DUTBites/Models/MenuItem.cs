using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTBites.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }

        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public decimal itemPrice { get; set; }
        // Navigation - MenuItem can appear in many OrderDetails

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}