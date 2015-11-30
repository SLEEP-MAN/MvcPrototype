using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcPrototype.Services.Interfaces;

namespace MvcPrototype.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("MvcPrototype.Services")
                .BasedOn<IService>()
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    }
}