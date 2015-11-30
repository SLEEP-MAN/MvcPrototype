using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcPrototype.DAL.Interfaces;

namespace MvcPrototype.Installers
{
    public class DALInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("MvcPrototype.DAL.Fake")
                .BasedOn<IDbContext>()
                .WithService.AllInterfaces()
                .LifestyleTransient());
            
            container.Register(Classes.FromAssemblyNamed("MvcPrototype.DAL.Fake")
                .BasedOn<IRepository>()
                .WithService.AllInterfaces()
                .LifestyleTransient());

        }
    }
}