using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest2.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter your UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }
    }
}