using System;
using System.Collections.Generic;
using Android.Content;
using Android.Locations;
using Android.App;
using YandexMetricaPCL;

namespace YandexMetricaAndroid
{
    public class YandexMetricaImplementation : IYandexMetrica
    {
        public static void Activate(Context context, string apiKey, Application app = null)
        {
            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());

            Com.Yandex.Metrica.YandexMetrica.Activate(context, apiKey);
            EnableActivityAutoTracking(app);

            // Native crashes are currently not supported
            Com.Yandex.Metrica.YandexMetrica.SetReportNativeCrashesEnabled(false);
        }

        public static void Activate(Context context, YandexMetricaConfig config, Application app = null)
        {
            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());

            var builder = Com.Yandex.Metrica.YandexMetricaConfig.NewConfigBuilder(config.ApiKey);

            if (config.Location != null) {
                builder.SetLocation(config.Location.ToLocation());
            }
            if (config.AppVersion != null) {
                builder.SetAppVersion(config.AppVersion);
            }
            if (config.TrackLocationEnabled.HasValue) {
                builder.SetTrackLocationEnabled(config.TrackLocationEnabled.Value);
            }
            if (config.SessionTimeout.HasValue) {
                builder.SetSessionTimeout(config.SessionTimeout.Value);
            }
            if (config.ReportCrashesEnabled.HasValue) {
                builder.SetReportCrashesEnabled(config.ReportCrashesEnabled.Value);
            }
            if (config.LoggingEnabled.HasValue && config.LoggingEnabled.Value) {
                builder.SetLogEnabled();
            }
            if (config.CollectInstalledApps.HasValue) {
                builder.SetCollectInstalledApps(config.CollectInstalledApps.Value);
            }
            if (config.PreloadInfo != null) {
                var preloadInfoBuilder = Com.Yandex.Metrica.PreloadInfo.NewBuilder(config.PreloadInfo.TrackingId);
                foreach (var kvp in config.PreloadInfo.AdditionalInfo) {
                    preloadInfoBuilder.SetAdditionalParams(kvp.Key, kvp.Value);
                }
                builder.SetPreloadInfo(preloadInfoBuilder.Build());
            }

            // Native crashes are currently not supported
            builder.SetReportNativeCrashesEnabled(false);

            Com.Yandex.Metrica.YandexMetrica.Activate(context, builder.Build());
            EnableActivityAutoTracking(app);
        }

        private static void EnableActivityAutoTracking(Application app)
        {
            if (app != null) {
                Com.Yandex.Metrica.YandexMetrica.EnableActivityAutoTracking(app);
            }
        }

        public static void OnPauseActivity(Activity activity)
        {
            Com.Yandex.Metrica.YandexMetrica.OnPauseActivity(activity);
        }

        public static void OnResumeActivity(Activity activity)
        {
            Com.Yandex.Metrica.YandexMetrica.OnResumeActivity(activity);
        }

        public void ReportEvent(string message)
        {
            Com.Yandex.Metrica.YandexMetrica.ReportEvent(message);
        }

        public void ReportEvent(string message, IDictionary<string, string> parameters) 
        {
            var jObjDict = new Dictionary<string, Java.Lang.Object>();
            foreach (var kvp in parameters) {
                jObjDict.Add(kvp.Key, kvp.Value);
            }
            Com.Yandex.Metrica.YandexMetrica.ReportEvent(message, jObjDict);
        } 

        public void ReportError(string message, Exception exception) 
        {
            var throwable = Java.Lang.Throwable.FromException(exception);
            Com.Yandex.Metrica.YandexMetrica.ReportError(message, throwable);
        }

        public void SetTrackLocationEnabled(bool enabled) 
        {
            Com.Yandex.Metrica.YandexMetrica.SetTrackLocationEnabled(enabled);
        }

        public void SetLocation(Coordinates coordinates) 
        {
            Com.Yandex.Metrica.YandexMetrica.SetLocation(coordinates.ToLocation());
        }

        public void SetSessionTimeout(uint sessionTimeoutSeconds) 
        {
            Com.Yandex.Metrica.YandexMetrica.SetSessionTimeout((int)sessionTimeoutSeconds);
        }

        public void SetReportCrashesEnabled(bool enabled) 
        {
            Com.Yandex.Metrica.YandexMetrica.SetReportCrashesEnabled(enabled);
        }

        public void SetCustomAppVersion(string appVersion)
        {
            Com.Yandex.Metrica.YandexMetrica.SetCustomAppVersion(appVersion);
        }

        public void SetLoggingEnabled()
        {
            Com.Yandex.Metrica.YandexMetrica.SetLogEnabled();
        }

        public void SetEnvironmentValue(string key, string value)
        {
            Com.Yandex.Metrica.YandexMetrica.SetEnvironmentValue(key, value);
        }

        public bool CollectInstalledApps { 
            get { 
                return Com.Yandex.Metrica.YandexMetrica.CollectInstalledApps;
            } 
            set {
                Com.Yandex.Metrica.YandexMetrica.CollectInstalledApps = value;
            } 
        }

        public string LibraryVersion { get { return Com.Yandex.Metrica.YandexMetrica.LibraryVersion; } }

        public int LibraryApiLevel { get { return Com.Yandex.Metrica.YandexMetrica.LibraryApiLevel; } }
    }

    public static class Extensions 
    {
        public static Location ToLocation(this Coordinates self)
        {
            return self == null ? null : new Location("") {
                Latitude = self.Latitude,
                Longitude = self.Longitude
            };
        }
    }
}

