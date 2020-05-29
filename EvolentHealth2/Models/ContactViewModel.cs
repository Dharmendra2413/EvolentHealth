using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvolentHealth2.Models
{
    public class ContactViewModel
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "You must provide a FirstName")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "You must provide a LastName")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }
}