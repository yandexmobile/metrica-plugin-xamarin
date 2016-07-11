using System;

namespace YandexMetricaPCL
{
    public sealed class YandexMetricaConfig
    {
        public string ApiKey { get; private set; }
        public string AppVersion { get; set; }
        public Coordinates Location { get; set; }
        public int? SessionTimeout { get; set; }
        public bool? ReportCrashesEnabled { get; set; }
        public bool? TrackLocationEnabled { get; set; }
        public bool? LoggingEnabled { get; set; }
        public bool? CollectInstalledApps { get; set; }

        public YandexMetricaPreloadInfo PreloadInfo { get; set; }

        public YandexMetricaConfig(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
