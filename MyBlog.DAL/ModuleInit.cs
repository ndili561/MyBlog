using Microsoft.Extensions.DependencyInjection;
using MyBlog.Common;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace MyBlog.DAL
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Add(typeof(IDataBaseRepository), typeof(DatabaseContext),
                ServiceLifetime.Transient);
        }
    }
}
