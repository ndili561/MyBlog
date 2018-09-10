using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class InfoDTO
    {
      
        public int id { get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email address is missing"), EmailAddress(ErrorMessage = "Email is not valid")]
        public string email { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public string company { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string message { get; set; }
    }
}
