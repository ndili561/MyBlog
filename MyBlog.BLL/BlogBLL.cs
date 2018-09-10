using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Common;
using MyBlog.Common.Entities;
using MyBlog.DAL;
using MyBlog.DAL.Model;

namespace MyBlog.BLL
{
    public class BlogBLL : ICommentService
    {
        private readonly DatabaseContext _usersRepository;

        public BlogBLL(DatabaseContext usersRepository)
        {
            _usersRepository = usersRepository;
        }



        public async Task<IComment> addComment(IComment comment)
        {
            comment.date = DateTime.Now;
            await _usersRepository.AddAsync(comment);
            await _usersRepository.SaveChangesAsync();
            return comment;
        }

        public List<IComment> GetallComment(int id)
        {
            var result = _usersRepository.Comments.Where(x => x.blogid == id).ToList();
            return result.ToList<IComment>();
           
        }

        public async Task<IInfo> addInfo(IInfo info)
        {
           var result= await _usersRepository.AddAsync(info);
           await _usersRepository.SaveChangesAsync();
           return info;
            
        }
    }
}
