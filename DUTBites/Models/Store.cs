using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUTBites.Models
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreID { get; set; }
        public Store store { get; set; }
        [ForeignKey("Campus")]
        public int CampusID { get; set; }
        [ForeignKey("CampusID")]
        public Campus Campuss { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Campus> Campus { get; set; }
    }
}