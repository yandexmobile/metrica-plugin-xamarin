/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using Foundation;
using CoreLocation;
using YandexMetricaPCL;

namespace YandexMetricaIOS
{
    public class YandexMetricaImplementation : BaseYandexMetrica
    {
        public static void Activate(YandexMetricaConfig config)
        {
            YMMYandexMetrica.ActivateWithConfiguration(config.ToIOSAppMetricaConfig());

            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());
            UpdateConfiguration(config);
        }

        public override void ReportEvent(string message)
        {
            YMMYandexMetrica.ReportEvent(message, null);
        }

        public override void ReportEvent(string message, System.Collections.Generic.IDictionary<string, string> parameters) 
        { 
            var dict = new NSMutableDictionary();
            foreach (var kvp in parameters) {
                dict.Add(new NSString(kvp.Key), new NSString(kvp.Value));
            }
            YMMYandexMetrica.ReportEvent(message, dict, null);
        } 

        public override void ReportError(string message, Exception exception) 
        { 
            var nsException = new NSException(exception.Source, exception.Message, null);
            YMMYandexMetrica.ReportError(message, nsException, null);
        }

        public override void SetLocationTracking(bool enabled) 
        { 
            YMMYandexMetrica.SetLocationTracking(enabled);
        }

        public override void SetLocation(Coordinates coordinates) 
        {
            YMMYandexMetrica.SetLocation(coordinates.ToCLLocation());
        }

        public override string LibraryVersion { get { return YMMYandexMetrica.LibraryVersion; } }

        public override int LibraryApiLevel { get { return default(int); } }
    }

    public static class YandexAppMetricaExtensionsIOS
    {
        public static YMMYandexMetricaConfiguration ToIOSAppMetricaConfig(this YandexMetricaConfig self)
        {
            var nativeConfig = new YMMYandexMetricaConfiguration(self.ApiKey);

            if (self.Location != null)
            {
                nativeConfig.Location = self.Location.ToCLLocation();
            }
            if (self.AppVersion != null)
            {
                nativeConfig.AppVersion = self.AppVersion;
            }
            if (self.LocationTracking.HasValue)
            {
                nativeConfig.LocationTracking = self.LocationTracking.Value;
            }
            if (self.SessionTimeout.HasValue)
            {
                nativeConfig.SessionTimeout = (nuint)self.SessionTimeout.Value;
            }
            if (self.CrashReporting.HasValue)
            {
                nativeConfig.CrashReporting = self.CrashReporting.Value;
            }
            if (self.Logs.HasValue)
            {
                nativeConfig.Logs = self.Logs.Value;
            }
            if (self.PreloadInfo != null)
            {
                var preloadInfo = new YMMYandexMetricaPreloadInfo(self.PreloadInfo.TrackingId);
                foreach (var kvp in self.PreloadInfo.AdditionalInfo)
                {
                    preloadInfo.SetAdditionalInfo(kvp.Value, kvp.Key);
                }
                nativeConfig.PreloadInfo = preloadInfo;
            }

            return nativeConfig;
        }

        public static CLLocation ToCLLocation(this Coordinates self)
        {
            return self == null ? null : new CLLocation(self.Latitude, self.Longitude);
        }
    }
}

