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
            var config = new YandexMetricaConfig(ApiKey());
            config.TrackLocationEnabled = false;
            config.CollectInstalledApps = false;

            return config;
        }

        public App()
        {
			MainPage = new Metrica.Sample.Forms.MainPage ();
        }
    }
}

