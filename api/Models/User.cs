using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class User
    {
      
      public int UserId { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter Name")]

        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]

        public string Email { get; set; }
    
}
}