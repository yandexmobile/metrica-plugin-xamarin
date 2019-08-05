/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace YandexMetricaPCL
{
    public static class YandexMetrica
    {
        private static IYandexMetrica _implementation = null;
        private static bool _activated = false;

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
                _activated = true;
            }
        }

        public static bool IsActivated {
            get {
                return _activated;
            }
        }
    }
}

