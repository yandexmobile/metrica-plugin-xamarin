using System;
using System.Collections.Generic;

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
        public abstract void ReportEvent(string message, IDictionary<string, string> parameters);
        public abstract void SetLocation(Coordinates coordinates);
        public abstract void SetLocationTracking(bool enabled);
    }
}
