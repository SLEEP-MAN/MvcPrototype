using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcPrototype.SubResolvers;

namespace MvcPrototype.Installers
{
    public class SubResolversInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new LoggerSubDependencyResolver());
        }
    }
}