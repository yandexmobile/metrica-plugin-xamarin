using System;
using System.Collections.Generic;

namespace YandexMetricaPCL
{
    public sealed class YandexMetricaPreloadInfo
    {
        public string TrackingId { get; private set; }
        public Dictionary<string, string> AdditionalInfo { get; private set; }

        public YandexMetricaPreloadInfo(string trackingId)
        {
            TrackingId = trackingId;
            AdditionalInfo = new Dictionary<string, string>();
        }
    }
}
