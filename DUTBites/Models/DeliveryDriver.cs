using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace DUTBites.Models
{
    public class DeliveryDriver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string LicensePlate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime LastKnownLocationTimestamp { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<DeliveryLocation> Locations { get; set; }
    }

}