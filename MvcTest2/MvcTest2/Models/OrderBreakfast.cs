using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest2.Models
{
    public class OrderBreakfast
    {
        public string bftype { get; set; }
        public string bfppl { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name1 { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid Email id")]
        public string email1 { get; set; }

        [Required(ErrorMessage = "Please enter yur phone number")]
        public string Phone1 { get; set; }

        [Required(ErrorMessage = "Please tell us your location")]
        public string Location1 { get; set; }

        [Required(ErrorMessage = "Please write your message for us in sort")]
        public string Message1 { get; set; }
    }
}