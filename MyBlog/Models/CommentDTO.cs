using MyBlog.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class CommentDTO
    {
        
      

        [Required (ErrorMessage ="Comment is required")]
        public string comment { get; set; }
        [Required(ErrorMessage = "Author name is required")]
        public string author { get; set; }
        [Required(ErrorMessage ="Email address is missing"), EmailAddress(ErrorMessage = "Email is not valid")]
        public string authormail { get; set; }
        public int blogid { get; set; }
        public DateTime date { get; set; }
        public InfoDTO info { get; set; }
        public List<Comment> comments { get; set; }
     
    }
}
