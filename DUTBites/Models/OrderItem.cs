using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTBites.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        // FK to MenuItem
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }
    }
}