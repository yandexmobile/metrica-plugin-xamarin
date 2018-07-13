/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using Android.App;
using Android.Runtime;

namespace Metrica.Xamarin.CrossPlatform.Droid
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
            YandexMetricaAndroid.YandexMetricaImplementation.Activate(this, SharedLogic.AppMetricaConfig(), this);
        }
    }
}
