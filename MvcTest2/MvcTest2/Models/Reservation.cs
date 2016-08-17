using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.ComponentModel.DataAnnotations;

namespace MvcTest2.Models
{
    public class Reservation 
    {
        public bool EnableSsl { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid Email id")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter yur phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please tell us your location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please write your reason to contact us in few words")]
        public string Message { get; set; }
    }
}