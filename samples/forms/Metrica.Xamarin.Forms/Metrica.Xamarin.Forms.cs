/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;
using YandexMetricaPCL;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metrica.Sample.Forms
{
    public class App : Application
    {
        public static string ApiKey()
        {
            // Return your API key here.
            throw new NotImplementedException();
        }

        public static YandexMetricaConfig AppMetricaConfig()
        {
            return new YandexMetricaConfig(ApiKey())
            {
                InstalledAppCollecting = true,
                CrashReporting = true,
                LocationTracking = true,
                Logs = true
            };
        }

        public App()
        {
			MainPage = new Metrica.Sample.Forms.MainPage ();
        }
    }
}

