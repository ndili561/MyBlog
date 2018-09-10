using MyBlog.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace MyBlog.Common
{
    public interface ICommentService 
    {
        Task<IComment> addComment(IComment comment);
        List<IComment> GetallComment(int id);
        Task<IInfo> addInfo(IInfo info);
    }
}
