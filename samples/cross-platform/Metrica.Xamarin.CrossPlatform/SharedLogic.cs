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

