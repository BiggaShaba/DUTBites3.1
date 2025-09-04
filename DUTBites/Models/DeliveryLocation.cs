using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    
using System.ComponentModel.DataAnnotations.Schema;


namespace DUTBites.Models
{
    public class DeliveryLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public int DriverID { get; set; }
        public virtual DeliveryDriver DeliveryDriver { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public DateTime timestamp { get; set; } 
    }
}