/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using YandexMetricaPCL;

namespace Metrica.Xamarin.CrossPlatform.Droid
{
    [Activity(Label = "Metrica.Xamarin.CrossPlatform", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private static int clicksCount = 0;
        private static int errorsCount = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Button logClickButton = FindViewById<Button>(Resource.Id.logClickButton);
            logClickButton.Click += (s, e) => {
                ++clicksCount;
                logClickButton.Text = string.Format("{0} clicks logged", clicksCount);

                var dict = new Dictionary<string, string> { { "click", clicksCount.ToString() } };
                YandexMetrica.Implementation.ReportEvent("Click from Android", dict);

                SharedLogic.LogClick(clicksCount);
            };

            Button logErrorButton = FindViewById<Button>(Resource.Id.logErrorButton);
            logErrorButton.Click += (s, e) => {
                ++errorsCount;
                logErrorButton.Text = string.Format("{0} errors logged", errorsCount);
                SharedLogic.LogError(errorsCount);
            };
        }
    }
}


