using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class InsertData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Number", AllowEmptyStrings = false)]
        public string Number { get; set; }
        [Required(ErrorMessage = "Please enter your email address", AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Message in few words", AllowEmptyStrings = false)]
        public string Message { get; set; }
    }
}