/*
 * Version for Xamarin
 * © 2018-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using Android.App;
using Android.Runtime;

namespace Metrica.Sample.Forms.Droid
{
    [Application]
    public class CustomApplication : Application
    {
        public CustomApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            // Init Android AppMetrica directly
            var config = App.AppMetricaConfig();
            YandexMetricaAndroid.YandexMetricaImplementation.Activate(this, config, this);
        }
    }
}
