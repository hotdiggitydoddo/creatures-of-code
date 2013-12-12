using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JotAThought.Web.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(16, MinimumLength=3, ErrorMessage="Your user name must be a minimum of 3 characters and no more than 16 characters")]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(16, MinimumLength=8)]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}