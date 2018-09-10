using MyBlog.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.DAL.Model
{
    public class Comment : IComment
    {
        [Key]
        public int Id { get; set; }
        public string comment { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        [ForeignKey("BlogForeignKey")]
        public int blogid { get; set; }       
        public DateTime date { get; set; }
        [NotMapped]
        public IInfo info { get; set; }
    }
}
