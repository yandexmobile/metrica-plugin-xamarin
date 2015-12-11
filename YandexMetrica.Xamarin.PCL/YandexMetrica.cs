using System;
using System.Collections.Generic;
using System.Reflection;

namespace YandexMetricaPCL
{
    public static class YandexMetrica
    {
        private static IYandexMetrica _implementation = null;

        /// <summary>
        /// Gets an AppMetrica implementation.
        /// </summary>
        /// <value>The implementation.</value>
        public static IYandexMetrica Implementation { 
            get { 
                return _implementation ?? (_implementation = new YandexMetricaDummy()); 
            } 
        }

        public static void RegisterImplementation(IYandexMetrica metricaImplementation)
        {
            if (metricaImplementation != null) {
                _implementation = metricaImplementation;
            }
        }
    }
}

