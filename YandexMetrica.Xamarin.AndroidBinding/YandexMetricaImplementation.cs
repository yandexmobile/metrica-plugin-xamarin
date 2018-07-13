/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;
using Android.Content;
using Android.Locations;
using Android.App;
using YandexMetricaPCL;

namespace YandexMetricaAndroid
{
    public class YandexMetricaImplementation : BaseYandexMetrica
    {
        public static void Activate(Context context, YandexMetricaConfig config, Application app = null)
        {
            Com.Yandex.Metrica.YandexMetrica.Activate(context, config.ToAndroidMetricaConfig());
            EnableActivityAutoTracking(app);

            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());
            UpdateConfiguration(config);
        }

        private static void EnableActivityAutoTracking(Application app)
        {
            if (app != null) {
                Com.Yandex.Metrica.YandexMetrica.EnableActivityAutoTracking(app);
            }
        }

        public static void PauseSession(Activity activity)
        {
            Com.Yandex.Metrica.YandexMetrica.PauseSession(activity);
        }

        public static void ResumeSession(Activity activity)
        {
            Com.Yandex.Metrica.YandexMetrica.ResumeSession(activity);
        }

        public override void ReportEvent(string message)
        {
            Com.Yandex.Metrica.YandexMetrica.ReportEvent(message);
        }

        public override void ReportEvent(string message, IDictionary<string, string> parameters)
        {
            var jObjDict = new Dictionary<string, Java.Lang.Object>();
            foreach (var kvp in parameters) {
                jObjDict.Add(kvp.Key, kvp.Value);
            }
            Com.Yandex.Metrica.YandexMetrica.ReportEvent(message, jObjDict);
        } 

        public override void ReportError(string message, Exception exception)
        {
            var throwable = Java.Lang.Throwable.FromException(exception);
            Com.Yandex.Metrica.YandexMetrica.ReportError(message, throwable);
        }

        public override void SetLocationTracking(bool enabled)
        {
            Com.Yandex.Metrica.YandexMetrica.SetLocationTracking(enabled);
        }

        public override void SetLocation(Coordinates coordinates)
        {
            Com.Yandex.Metrica.YandexMetrica.SetLocation(coordinates.ToLocation());
        }

        public override string LibraryVersion { get { return Com.Yandex.Metrica.YandexMetrica.LibraryVersion; } }

        public override int LibraryApiLevel { get { return Com.Yandex.Metrica.YandexMetrica.LibraryApiLevel; } }
    }

    public static class YandexMetricaExtensionsAndroid
    {
        public static Com.Yandex.Metrica.YandexMetricaConfig ToAndroidMetricaConfig(this YandexMetricaConfig self)
        {
            var builder = Com.Yandex.Metrica.YandexMetricaConfig.NewConfigBuilder(self.ApiKey);

            if (self.Location != null)
            {
                builder.WithLocation(self.Location.ToLocation());
            }
            if (self.AppVersion != null)
            {
                builder.WithAppVersion(self.AppVersion);
            }
            if (self.LocationTracking.HasValue)
            {
                builder.WithLocationTracking(self.LocationTracking.Value);
            }
            if (self.SessionTimeout.HasValue)
            {
                builder.WithSessionTimeout(self.SessionTimeout.Value);
            }
            if (self.CrashReporting.HasValue)
            {
                builder.WithCrashReporting(self.CrashReporting.Value);
            }
            if (self.Logs.HasValue && self.Logs.Value)
            {
                builder.WithLogs();
            }
            if (self.InstalledAppCollecting.HasValue)
            {
                builder.WithInstalledAppCollecting(self.InstalledAppCollecting.Value);
            }
            if (self.PreloadInfo != null)
            {
                var preloadInfoBuilder = Com.Yandex.Metrica.PreloadInfo.NewBuilder(self.PreloadInfo.TrackingId);
                foreach (var kvp in self.PreloadInfo.AdditionalInfo)
                {
                    preloadInfoBuilder.SetAdditionalParams(kvp.Key, kvp.Value);
                }
                builder.WithPreloadInfo(preloadInfoBuilder.Build());
            }

            // Native crashes are currently not supported
            builder.WithNativeCrashReporting(false);

            return builder.Build();
        }

        public static Location ToLocation(this Coordinates self)
        {
            return self == null ? null : new Location("")
            {
                Latitude = self.Latitude,
                Longitude = self.Longitude
            };
        }
    }
}

