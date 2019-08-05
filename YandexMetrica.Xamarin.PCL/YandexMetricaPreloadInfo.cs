/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

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
