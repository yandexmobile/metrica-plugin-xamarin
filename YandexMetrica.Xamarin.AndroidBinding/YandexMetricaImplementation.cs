/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections;
using Android.App;
using Android.Content;
using Android.Locations;
using Java.Util;
using YandexMetricaPCL;
using YandexMetricaPCL.SimpleJson;

namespace YandexMetricaAndroid
{
    public class YandexMetricaImplementation : BaseYandexMetrica
    {
        public static void Activate(Context context, YandexMetricaConfig config, Application app = null)
        {
            Com.Yandex.Metrica.YandexMetrica.Activate(context, config.ToAndroidMetricaConfig());
            EnableActivityAutoTracking(app);

            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());
            YandexMetricaAttributeImplementation.Init();
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

        public override void ReportEvent(string message, IDictionary parameters)
        {

            Com.Yandex.Metrica.YandexMetrica.ReportEvent(message, parameters.ToJsonString());
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

        public override void SendEventsBuffer()
        {
            Com.Yandex.Metrica.YandexMetrica.SendEventsBuffer();
        }

        public override void SetStatisticsSending(bool enabled)
        {
            Com.Yandex.Metrica.YandexMetrica.SetStatisticsSending(Application.Context, enabled);
        }

        public override void ReportRevenue(YandexAppMetricaRevenue revenue)
        {
            Com.Yandex.Metrica.YandexMetrica.ReportRevenue(revenue.ToAndroidRevenue());
        }
        
        public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
        {
            Com.Yandex.Metrica.YandexMetrica.RequestAppMetricaDeviceID(new AppMetricaDeviceIDListener(action));
        }

        public override void SetUserProfileID(string userProfileID)
        {
            Com.Yandex.Metrica.YandexMetrica.SetUserProfileID(userProfileID);
        }

        public override void ReportUserProfile(YandexMetricaUserProfile userProfile)
        {
            Com.Yandex.Metrica.YandexMetrica.ReportUserProfile(userProfile.ToAndroidUserProfile());
        }

        public override string LibraryVersion { get { return Com.Yandex.Metrica.YandexMetrica.LibraryVersion; } }

        public override int LibraryApiLevel { get { return Com.Yandex.Metrica.YandexMetrica.LibraryApiLevel; } }
    }

    class AppMetricaDeviceIDListener : Java.Lang.Object, Com.Yandex.Metrica.IAppMetricaDeviceIDListener
    {
        private readonly Action<string, YandexAppMetricaRequestDeviceIDError?> _action;

        public AppMetricaDeviceIDListener(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
        {
            _action = action;
        }

        public void OnLoaded(string deviceID)
        {
            _action.Invoke(deviceID, null);
        }

        public void OnError(Com.Yandex.Metrica.AppMetricaDeviceIDListenerReason reason)
        {
            _action.Invoke(null, RequestDeviceIDErrorFromAndroidReason(reason));
        }

        private YandexAppMetricaRequestDeviceIDError? RequestDeviceIDErrorFromAndroidReason(Com.Yandex.Metrica.AppMetricaDeviceIDListenerReason reason)
        {
            if (reason == null)
            {
                return null;
            }
            try
            {
                var error = Enum.Parse(typeof(YandexAppMetricaRequestDeviceIDError), reason.ToString());
                return (YandexAppMetricaRequestDeviceIDError?)error;
            }
            catch (ArgumentException)
            {
                return YandexAppMetricaRequestDeviceIDError.UNKNOWN;
            }
        }
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
            if (self.StatisticsSending.HasValue)
            {
                builder.WithStatisticsSending(self.StatisticsSending.Value);
            }
            if (self.HandleFirstActivationAsUpdate.HasValue)
            {
                builder.HandleFirstActivationAsUpdate(self.HandleFirstActivationAsUpdate.Value);
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

        public static Com.Yandex.Metrica.Revenue ToAndroidRevenue(this YandexAppMetricaRevenue self)
        {
            var builder = Com.Yandex.Metrica.Revenue.NewBuilder(self.Price, self.Currency.ToAndroidCurrency());

            if (self.Quantity.HasValue)
            {
                builder.WithQuantity(new Java.Lang.Integer(self.Quantity.Value));
            }
            if (self.ProductID != null)
            {
                builder.WithProductID(self.ProductID);
            }
            if (self.Payload != null)
            {
                builder.WithPayload(self.Payload.ToJsonString());
            }
            if (self.Receipt.HasValue)
            {
                builder.WithReceipt(self.Receipt.Value.ToAndroidReceipt());
            }

            return builder.Build();
        }

        public static Com.Yandex.Metrica.Revenue.Receipt ToAndroidReceipt(this YandexAppMetricaReceipt self)
        {
            var builder = Com.Yandex.Metrica.Revenue.Receipt.NewBuilder();

            if (self.Data != null)
            {
                builder.WithData(self.Data);
            }
            if (self.Signature != null)
            {
                builder.WithSignature(self.Signature);
            }

            return builder.Build();
        }

        public static Currency ToAndroidCurrency(this string self)
        {
            return self == null ? null : Currency.GetInstance(self);
        }

        public static string ToJsonString(this IDictionary self)
        {
            return self == null ? null : SimpleJson.SerializeObject(self);
        }

        public static Com.Yandex.Metrica.Profile.UserProfile ToAndroidUserProfile(this YandexMetricaUserProfile self)
        {
            var builder = Com.Yandex.Metrica.Profile.UserProfile.NewBuilder();

            self.UserProfileUpdates.ForEach((userProflieUpdate) => 
            {
                if (userProflieUpdate.Native != null)
                {
                    builder.Apply(userProflieUpdate.Native as Com.Yandex.Metrica.Profile.UserProfileUpdate);
                }
            });

            return builder.Build();
        }
    }
}

