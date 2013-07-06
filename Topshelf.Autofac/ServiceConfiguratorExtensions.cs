using Autofac;
using Topshelf.ServiceConfigurators;

namespace Topshelf.Autofac
{
    public static class ServiceConfiguratorExtensions
    {
        #region Public Methods and Operators

        public static ServiceConfigurator<T> ConstructUsingAutofacContainer<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            configurator.ConstructUsing(serviceFactory => AutofacHostBuilderConfigurator.LifetimeScope.Resolve<T>());
            return configurator;
        }

        #endregion
    }
}