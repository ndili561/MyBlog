using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MyBlog.Common
{
    public interface IModuleRegistrar
    {
        void Add(Type serviceType, Type implementationType, ServiceLifetime lifetime);
    }
}
