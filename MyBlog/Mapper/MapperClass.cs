using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;
using AutoMapper;
using MyBlog.DAL.Model;

namespace MyBlog
{
    public class MapperClass : Profile
    {
        public MapperClass() : this("MyProfile")
        {
        }

        protected MapperClass(string profileName): base(profileName)
        {
            CreateMap<CommentDTO, Comment>()
            .ForMember(vm => vm.comment, map => map.MapFrom(m => m.comment))
            .ForMember(vm => vm.name, map => map.MapFrom(m => m.author))
            .ForMember(vm => vm.email, map => map.MapFrom(m => m.authormail))
            .ForMember(vm => vm.blogid, map => map.MapFrom(m => m.blogid));
            CreateMap<InfoDTO, Info>()
                .ForMember(vm => vm.Email, map => map.MapFrom(m => m.email));

        }
    }
}
