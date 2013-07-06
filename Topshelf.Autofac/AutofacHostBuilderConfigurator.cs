using System;
using System.Collections.Generic;
using Autofac;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Autofac
{
    public class AutofacHostBuilderConfigurator : HostBuilderConfigurator
    {
        #region Static Fields

        private static ILifetimeScope lifetimeScope;

        #endregion

        #region Constructors and Destructors

        public AutofacHostBuilderConfigurator(ILifetimeScope lifetimeScope)
        {
            if (lifetimeScope == null)
            {
                throw new ArgumentNullException("lifetimeScope");
            }

            AutofacHostBuilderConfigurator.lifetimeScope = lifetimeScope;
        }

        #endregion

        #region Public Properties

        public static ILifetimeScope LifetimeScope
        {
            get
            {
                return lifetimeScope;
            }
        }

        #endregion

        #region Public Methods and Operators

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        #endregion
    }
}