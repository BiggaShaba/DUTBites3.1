using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUTBites.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int? DriverId { get; set; }
        public virtual DeliveryDriver DeliveryDriver { get; set; }
        public orderStatus status { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Payment Payment { get; set; }
    }

    public enum orderStatus
    {
        Pending = 0,
        Preparing = 1,
        OnTheWay = 2,
        Delivered = 3,
        Cancelled = 4,
    }
}