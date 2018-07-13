/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using UIKit;
using Foundation;
using YandexMetricaPCL;
using System.Collections.Generic;

namespace Metrica.Xamarin.CrossPlatform.iOS
{
    public partial class ViewController : UIViewController
    {
        private static int clicksCount = 0;
        private static int errorsCount = 0;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Init iOS AppMetrica directly
            YandexMetricaIOS.YandexMetricaImplementation.Activate(SharedLogic.AppMetricaConfig());

            LogClickButton.AccessibilityIdentifier = "logClickButton";
            LogClickButton.TouchUpInside += delegate {
                ++clicksCount;
                var title = string.Format("{0} clicks logged", clicksCount);
                LogClickButton.SetTitle(title, UIControlState.Normal);

                var dict = new Dictionary<string, string> { { "click", clicksCount.ToString() } };
                YandexMetrica.Implementation.ReportEvent("Click from iOS", dict);

                SharedLogic.LogClick(clicksCount);
            };

            LogErrorButton.AccessibilityIdentifier = "logErrorButton";
            LogErrorButton.TouchUpInside += delegate {
                ++errorsCount;
                var title = string.Format("{0} errors logged", errorsCount);
                LogErrorButton.SetTitle(title, UIControlState.Normal);

                SharedLogic.LogError(errorsCount);
            };
        }
    }
}
