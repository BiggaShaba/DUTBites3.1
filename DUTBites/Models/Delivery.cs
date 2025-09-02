using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DUTBites.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryID { get; set; }
        public int orderId { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
        public int driverID { get; set; }
        [ForeignKey("DriverID")]
        public DeliveryDriver DeliveryDriverss { get; set; }
        public DeliveryStatus status { get; set; }
        public DateTime assignedAt { get; set; }
        public DateTime completedAt { get; set; }

        public virtual ICollection<DeliveryLocation> Locations { get; set; }
        public virtual ICollection<DeliveryDriver> DeliveryDrivers { get; set; } 
    }
    public enum DeliveryStatus
    {
        Assigned,
        PickedUp,
        OnTheWay,
        Delivered,
    }
}