using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBlog.DAL.Model;

namespace MyBlog.DAL
{
    public class DatabaseContext : DbContext,IDataBaseRepository
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
      

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Info> Infos { get; set; }


    }
}
