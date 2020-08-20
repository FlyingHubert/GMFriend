using Ninject;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMFriend.DependencyInjection
{
    public static class DI
    {
        private static IReadOnlyKernel kernel;

        static DI()
        {
            kernel = new KernelConfiguration(new ModuleBindings()).BuildReadonlyKernel();
        }

        public static T Get<T>() => kernel.Get<T>();
    }
}