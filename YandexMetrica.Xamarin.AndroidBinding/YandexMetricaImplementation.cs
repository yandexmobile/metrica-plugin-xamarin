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
            if (app != null) {
                Com.Yandex.Metrica.YandexMetrica.EnableActivityAutoTracking(app);
            }

            // Native crashes are currently not supported
            Com.Yandex.Metrica.YandexMetrica.SetReportNativeCrashesEnabled(false);
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

        public void SetLocation(float latitude, float longitude) 
        { 
            var location = new Location("") {
                Latitude = latitude,
                Longitude = longitude
            };
            Com.Yandex.Metrica.YandexMetrica.SetLocation(location);
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
}

