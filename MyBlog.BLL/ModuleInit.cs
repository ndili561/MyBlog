using MyBlog.Common;
using System.Composition;
using Microsoft.Extensions.DependencyInjection;

namespace MyBlog.BLL
{

    [Export(typeof(IModule))]
        public class ModuleInit : IModule
        {
            public void Initialize(IModuleRegistrar registrar)
            {
                registrar.Add(typeof(ICommentService), typeof(BlogBLL),
                    ServiceLifetime.Transient);
            }
        }
    
}
