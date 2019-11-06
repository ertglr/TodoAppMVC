using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoAppApi.Models
{
    public class UserVM
    {
        public Guid ID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string ModifiedUser { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}