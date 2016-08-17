using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest2.Models
{
    public class OrderLunch
    {
        public string bftype { get; set; }
        public string bfppl { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid Email id")]
        public string email{ get; set; }

        [Required(ErrorMessage = "Please enter yur phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please tell us your location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please write your message for us in sort")]
        public string message { get; set; }
    }
}