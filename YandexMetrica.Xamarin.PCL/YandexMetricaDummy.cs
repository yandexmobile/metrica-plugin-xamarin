/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;

namespace YandexMetricaPCL
{
    /// <summary>
    /// AppMetrica empty implementation.
    /// </summary>
    public class YandexMetricaDummy : BaseYandexMetrica
    {
        public override void ReportEvent(string message) { }

        public override void ReportEvent(string message, IDictionary<string, string> parameters) { }

        public override void ReportError(string message, Exception exception) { }

        public override void SetLocationTracking(bool enabled) { }

        public override void SetLocation(Coordinates coordinates) { }

        public override string LibraryVersion { get { return default(string); } }

        public override int LibraryApiLevel { get { return default(int); } }
    }
}

