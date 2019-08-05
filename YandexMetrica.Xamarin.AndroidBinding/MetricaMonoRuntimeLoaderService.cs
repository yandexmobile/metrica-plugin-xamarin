/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace YandexMetricaAndroid
{
    /// <summary>
    /// This class does nothing, but it is needed to run the application with a custom Application class.
    /// </summary>
    [Service(Process = ":Metrica")]
    public class MetricaMonoRuntimeLoaderService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}
