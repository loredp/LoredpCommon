using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using LCommon.Components;

namespace LCommon.Autofac
{
    /// <summary>
    /// Autofac implementationi of IObjectContainer.
    /// </summary>
    public class AutofacObjectContainer : IObjectContainer
    {
        #region CTOR

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AutofacObjectContainer()
        {
            _container = new ContainerBuilder().Build();
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="containerBuilder"></param>
        public AutofacObjectContainer(ContainerBuilder containerBuilder)
        {
            _container = containerBuilder.Build();
        }

        #endregion

        #region property

        private readonly IContainer _container;

        public IContainer Container
        {
            get { return _container; }
        }

        #endregion

        #region IObjectContainer 成员

        /// <summary>
        /// Register a implementation type.
        /// </summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        public void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();

            var registrationBuilder = builder.RegisterType(implementationType);
            if (serviceName != null)
                registrationBuilder.Named(serviceName, implementationType);
            if (life == LifeStyle.Singleton)
                registrationBuilder.SingleInstance();

            builder.Update(_container);
        }

        /// <summary>
        /// Register a implementer type as a service implementation.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life"></param>
        public void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();

            var registrationBuilder = builder.RegisterType(implementationType).As(serviceType);
            if (serviceName != null)
                registrationBuilder.Named(serviceName, implementationType);
            if (life == LifeStyle.Singleton)
                registrationBuilder.SingleInstance();

            builder.Update(_container);
        }

        public void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            throw new NotImplementedException();
        }

        public void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            throw new NotImplementedException();
        }

        public TService Resolve<TService>() where TService : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            throw new NotImplementedException();
        }

        public object ResolveNamed(string serviceName, Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
