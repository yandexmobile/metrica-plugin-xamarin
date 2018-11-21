using System;
using System.Collections;

namespace YandexMetricaPCL
{
    public abstract class BaseYandexMetrica : IYandexMetrica
    {
        private static YandexMetricaConfig _metricaConfig;

        public static event ConfigUpdateHandler OnConfigUpdate;

        public static YandexMetricaConfig ActivationConfig {
            get {
                return _metricaConfig;
            }
        }

        protected static void UpdateConfiguration(YandexMetricaConfig config)
        {
            _metricaConfig = config;
            ConfigUpdateHandler receiver = OnConfigUpdate;
            if (receiver != null)
            {
                receiver(config);
            }
        }

        public abstract string LibraryVersion { get; }
        public abstract int LibraryApiLevel { get; }
        public abstract void ReportError(string message, Exception exception);
        public abstract void ReportEvent(string message);
        public abstract void ReportEvent(string message, IDictionary parameters);
        public abstract void SetLocation(Coordinates coordinates);
        public abstract void SetLocationTracking(bool enabled);
        public abstract void SendEventsBuffer();
        public abstract void SetStatisticsSending(bool enabled);
        public abstract void ReportRevenue(YandexAppMetricaRevenue revenue);
        public abstract void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action);
        public abstract void SetUserProfileID(string userProfileID);
        public abstract void ReportUserProfile(YandexMetricaUserProfile userProfile);
    }
}
