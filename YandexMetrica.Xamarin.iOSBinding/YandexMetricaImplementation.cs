/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections;
using System.Collections.Generic;
using CoreLocation;
using Foundation;
using YandexMetricaPCL;
using YandexMetricaPCL.SimpleJson;

namespace YandexMetricaIOS
{
    public class YandexMetricaImplementation : BaseYandexMetrica
    {
        public static void Activate(YandexMetricaConfig config)
        {
            YMMYandexMetrica.ActivateWithConfiguration(config.ToIOSAppMetricaConfig());

            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());
            YandexMetricaAttributeImplementation.Init();
            UpdateConfiguration(config);
        }

        public override void ReportEvent(string message)
        {
            YMMYandexMetrica.ReportEvent(message, null);
        }

        public override void ReportEvent(string message, IDictionary parameters) 
        { 
            YMMYandexMetrica.ReportEvent(message, parameters.ToIOSDictionary(), null);
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

        public override void SendEventsBuffer()
        {
            YMMYandexMetrica.SendEventsBuffer();
        }

        public override void SetStatisticsSending(bool enabled)
        {
            YMMYandexMetrica.SetStatisticsSending(enabled);
        }
        
        public override void ReportRevenue(YandexAppMetricaRevenue revenue)
        {
            YMMYandexMetrica.ReportRevenue(revenue.ToIOSAppMetricaRevenue(), null);
        }

        public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
        {
            YMMYandexMetrica.RequestAppMetricaDeviceIDWithCompletionQueue(null, (deviceID, error) => 
            {
                action.Invoke(deviceID, RequestDeviceIDErrorFromNSError(error));
            });
        }

        public override void SetUserProfileID(string userProfileID)
        {
            YMMYandexMetrica.SetUserProfileID(userProfileID);
        }

        public override void ReportUserProfile(YandexMetricaUserProfile userProfile)
        {
            YMMYandexMetrica.ReportUserProfile(userProfile.ToIOSUserProfile(), null);
        }

        public override string LibraryVersion { get { return YMMYandexMetrica.LibraryVersion; } }

        public override int LibraryApiLevel { get { return default(int); } }

        private YandexAppMetricaRequestDeviceIDError? RequestDeviceIDErrorFromNSError(NSError error)
        {
            if (error == null)
            {
                return null;
            }
            if (error.Domain.Equals(NSError.NSUrlErrorDomain)) 
            {
                return YandexAppMetricaRequestDeviceIDError.NETWORK;
            }
            return YandexAppMetricaRequestDeviceIDError.UNKNOWN;
        }
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
            if (self.StatisticsSending.HasValue)
            {
                nativeConfig.StatisticsSending = self.StatisticsSending.Value;
            }
            if (self.HandleFirstActivationAsUpdate.HasValue)
            {
                nativeConfig.HandleFirstActivationAsUpdate = self.HandleFirstActivationAsUpdate.Value;
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

        public static YMMRevenueInfo ToIOSAppMetricaRevenue(this YandexAppMetricaRevenue self)
        {
            var price = self.Price;
            var currency = self.Currency;
            var quantity = (nuint)(self.Quantity ?? 1);
            var productID = self.ProductID;
            var trasactionID = self.Receipt.HasValue ? self.Receipt.Value.TransactionID : null;
            var data = self.Receipt.HasValue ? new NSData(self.Receipt.Value.Data, 0) : null;
            var payload = self.Payload.ToIOSDictionary();

            return new YMMRevenueInfo(price, currency, quantity, productID, trasactionID, data, payload);
        }

        public static NSDictionary ToIOSDictionary(this IDictionary self)
        {
            if (self == null)
            {
                return null;
            }
            var jsonString = new NSString(SimpleJson.SerializeObject(self));
            var jsonData = jsonString.Encode(NSStringEncoding.UTF8);
            NSError error;
            return (NSDictionary)NSJsonSerialization.Deserialize(jsonData, 0, out error);
        }

        public static YMMUserProfile ToIOSUserProfile(this YandexMetricaUserProfile self)
        {
            var nativeUserProfileUpdates = new List<YMMUserProfileUpdate>();
            self.UserProfileUpdates.ForEach(userProfileUpdate =>
            {
                if (userProfileUpdate != null && userProfileUpdate.Native != null)
                {
                    nativeUserProfileUpdates.Add(userProfileUpdate.Native as YMMUserProfileUpdate);
                }
            });
            return new YMMUserProfile(nativeUserProfileUpdates.ToArray());
        }
    }
}

