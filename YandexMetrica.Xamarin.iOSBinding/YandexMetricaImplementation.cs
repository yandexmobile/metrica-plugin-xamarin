using System;
using Foundation;
using CoreLocation;
using YandexMetricaPCL;

namespace YandexMetricaIOS
{
    public class YandexMetricaImplementation : IYandexMetrica
    {
        public static void Activate(string apiKey)
        {
            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());

            YMMYandexMetrica.ActivateWithApiKey(apiKey);
        }

        public void ReportEvent(string message)
        {
            YMMYandexMetrica.ReportEvent(message, null);
        }

        public void ReportEvent(string message, System.Collections.Generic.IDictionary<string, string> parameters) 
        { 
            var dict = new NSMutableDictionary();
            foreach (var kvp in parameters) {
                dict.Add(new NSString(kvp.Key), new NSString(kvp.Value));
            }
            YMMYandexMetrica.ReportEvent(message, dict, null);
        } 

        public void ReportError(string message, Exception exception) 
        { 
            var nsException = new NSException(exception.Source, exception.Message, null);
            YMMYandexMetrica.ReportError(message, nsException, null);
        }

        public void SetTrackLocationEnabled(bool enabled) 
        { 
            YMMYandexMetrica.SetTrackLocationEnabled(enabled);
        }

        public void SetLocation(float latitude, float longitude) 
        { 
            var location = new CLLocation(latitude, longitude);
            YMMYandexMetrica.SetLocation(location);
        }

        public void SetSessionTimeout(uint sessionTimeoutSeconds) 
        { 
            YMMYandexMetrica.SetSessionTimeout(sessionTimeoutSeconds);
        }

        public void SetReportCrashesEnabled(bool enabled) 
        { 
            YMMYandexMetrica.SetReportCrashesEnabled(enabled);
        }

        public void SetCustomAppVersion(string appVersion) 
        {
            YMMYandexMetrica.SetCustomAppVersion(appVersion);
        }

        public void SetLoggingEnabled() 
        { 
            YMMYandexMetrica.SetLoggingEnabled(true);
        }

        public void SetEnvironmentValue(string key, string value) 
        { 
            YMMYandexMetrica.SetEnvironmentValue(value, key);
        }

        public bool CollectInstalledApps { get { return false; } set { /* Not used in iOS */ } }

        public string LibraryVersion { get { return YMMYandexMetrica.LibraryVersion; } }

        public int LibraryApiLevel { get { return default(int); } }
    }
}

