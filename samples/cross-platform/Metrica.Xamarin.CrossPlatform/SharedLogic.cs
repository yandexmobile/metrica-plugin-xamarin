/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using YandexMetricaPCL;
using System.Collections.Generic;

namespace Metrica.Xamarin.CrossPlatform
{
    public static class SharedLogic
    {
        public static string ApiKey()
        {
            // Return your API key here.
            throw new NotImplementedException();
        }

        public static YandexMetricaConfig AppMetricaConfig ()
        {
            var config = new YandexMetricaConfig (ApiKey ());
            config.InstalledAppCollecting = false;

            return config;
        }

        public static void LogClick(int clickNumber)
        {
            var dict = new Dictionary<string, string>{ { "click", clickNumber.ToString() } };
            YandexMetrica.Implementation.ReportEvent("Click from shared logic", dict);
        }

        public static void LogError(int errorNumber)
        {
            try {
                throw new Exception("I'm an exception #" + errorNumber);
            } catch (Exception ex) {
                YandexMetrica.Implementation.ReportError("Error from shared logic", ex);
            }
        }
    }
}

