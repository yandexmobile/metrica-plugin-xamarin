/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;

namespace YandexMetricaPCL
{
    public sealed class YandexMetricaConfig
    {
        public string ApiKey { get; private set; }
        public string AppVersion { get; set; }
        public Coordinates Location { get; set; }
        public int? SessionTimeout { get; set; }
        public bool? CrashReporting { get; set; }
        public bool? LocationTracking { get; set; }
        public bool? Logs { get; set; }
        public bool? InstalledAppCollecting { get; set; }
        public bool? StatisticsSending { get; set; }
        public bool? HandleFirstActivationAsUpdate { get; set; }

        public YandexMetricaPreloadInfo PreloadInfo { get; set; }

        public YandexMetricaConfig(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
