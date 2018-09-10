using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common.Entities
{
     public interface IInfo
    {
         int Id { get; set; }
         string Name { get; set; }
         string Email { get; set; }
         string Message { get; set; }
    }
}
