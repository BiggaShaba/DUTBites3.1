using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DUTBites.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [ForeignKey("Campus")]
        public int campusID { get; set; }
        [ForeignKey("campusID")]
        public Campus Campus { get; set; }
        public UserRole Role { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First Name must only contain letters")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First Name must only contain letters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter Campus")]
        [Display(Name = "Select Campus")]
        public campus Campuss { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Campus> Canpuses { get; set; }
        public virtual ICollection<DeliveryDriver> DeliveryDrivers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
    public enum UserRole
    {
        Admin,
        Driver,
        Customer,
        StoreOwner,
    }
    public enum campus
    {
        ML_Sultan,
        Steve_Biko,
        Ritson,
    }
}