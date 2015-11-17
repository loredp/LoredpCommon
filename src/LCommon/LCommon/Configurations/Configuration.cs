using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCommon.Components;
using LCommon.Logging;

namespace LCommon.Configurations
{
    public class Configuration
    {
        /// <summary>
        /// Provides the singleton access instance.
        /// </summary>
        public static Configuration Instance { get; private set; }

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        private Configuration() { }

        /// <summary>
        /// Create an instance of configuration.
        /// </summary>
        /// <returns></returns>
        public static Configuration Create()
        {
            if(Instance != null)
            {
                throw new Exception("Could not create configuration instance twice.");
            }

            Instance = new Configuration();
            return Instance;
        }

        /// <summary>
        /// Set a default configuration.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementer"></typeparam>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        /// <returns></returns>
        public Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class,TService
        {
            ObjectContainer.Register<TService, TImplementer>(serviceName, life);
            return this;
        }

        /// <summary>
        /// Set a default configuration.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementer"></typeparam>
        /// <param name="instance"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        /// <summary>
        /// Register components.
        /// </summary>
        /// <returns></returns>
        public Configuration RegisterComponents()
        {
            SetDefault<ILoggerFactory, LLoggerFactory>();
            //SetDefault<IBinarySerializer, DefaultBinarySerializer>();
            //SetDefault<IJsonSerializer, NotImplementedJsonSerializer>();
            //SetDefault<IScheduleService, ScheduleService>(null, LifeStyle.Transient);
            //SetDefault<IMessageFramer, LengthPrefixMessageFramer>(null, LifeStyle.Transient);
            //SetDefault<IOHelper, IOHelper>();
            return this;
        }

        /// <summary>
        /// Register a unhandled exception.
        /// </summary>
        /// <returns></returns>
        public Configuration RegisterUnhandledExceptionHandler()
        {
            var logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => logger.ErrorFormat("Unhandled exception : {0}", e.ExceptionObject);
            
            return this;
        }
    }
}
