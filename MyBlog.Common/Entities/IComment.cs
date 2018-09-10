using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common.Entities
{
    public interface IComment
    {
        
        int Id { get; set; }
        string comment { get; set; }
        string name { get; set; }
        string email { get; set; }
        int blogid { get; set; }
        DateTime date { get; set; }
        IInfo info { get; set; }

    }
}
