using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DUTBites.Models
{
    public class Campus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampusID { get; set; }
        public string CampusName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}