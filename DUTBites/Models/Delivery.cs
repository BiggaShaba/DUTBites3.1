using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTBites.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryID { get; set; }
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int DriverID { get; set; }
        public virtual DeliveryDriver DeliveryDrivers { get; set; }
        public DeliveryStatus status { get; set; }
        public DateTime assignedAt { get; set; }
        public DateTime completedAt { get; set; }
        public virtual ICollection<DeliveryLocation> Locations { get; set; } = new List<DeliveryLocation>();
    }
    public enum DeliveryStatus
    {
        Assigned,
        PickedUp,
        OnTheWay,
        Delivered,
    }
}