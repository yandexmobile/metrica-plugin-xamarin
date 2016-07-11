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

        public static void Activate(YandexMetricaConfig config)
        {
            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());

            var nativeConfig = new YMMYandexMetricaConfiguration(config.ApiKey);

            if (config.Location != null) {
                nativeConfig.Location = config.Location.ToCLLocation();
            }
            if (config.AppVersion != null) {
                nativeConfig.CustomAppVersion = config.AppVersion;
            }
            if (config.TrackLocationEnabled.HasValue) {
                nativeConfig.TrackLocationEnabled = config.TrackLocationEnabled.Value;
            }
            if (config.SessionTimeout.HasValue) {
                nativeConfig.SessionTimeout = (nuint)config.SessionTimeout.Value;
            }
            if (config.ReportCrashesEnabled.HasValue) {
                nativeConfig.ReportCrashesEnabled = config.ReportCrashesEnabled.Value;
            }
            if (config.LoggingEnabled.HasValue) {
                nativeConfig.LoggingEnabled = config.LoggingEnabled.Value;
            }
            if (config.PreloadInfo != null) {
                var preloadInfo = new YMMYandexMetricaPreloadInfo(config.PreloadInfo.TrackingId);
                foreach (var kvp in config.PreloadInfo.AdditionalInfo) {
					preloadInfo.SetAdditionalInfo(kvp.Value, kvp.Key);
                }
                nativeConfig.PreloadInfo = preloadInfo;
            }

            YMMYandexMetrica.ActivateWithConfiguration(nativeConfig);
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

        public void SetLocation(Coordinates coordinates) 
        {
            YMMYandexMetrica.SetLocation(coordinates.ToCLLocation());
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

    public static class Extensions 
    {
        public static CLLocation ToCLLocation(this Coordinates self)
        {
            return self == null ? null : new CLLocation(self.Latitude, self.Longitude);
        }
    }
}

