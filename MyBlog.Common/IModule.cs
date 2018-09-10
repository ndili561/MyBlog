using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common
{
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
