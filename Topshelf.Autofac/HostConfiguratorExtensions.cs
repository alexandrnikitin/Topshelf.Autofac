using Autofac;
using Topshelf.HostConfigurators;

namespace Topshelf.Autofac
{
    public static class HostConfiguratorExtensions
    {
        #region Public Methods and Operators

        public static HostConfigurator UseAutofacContainer(this HostConfigurator configurator, ILifetimeScope lifetimeScope)
        {
            configurator.AddConfigurator(new AutofacHostBuilderConfigurator(lifetimeScope));
            return configurator;
        }

        #endregion
    }
}