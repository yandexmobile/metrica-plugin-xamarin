/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using CoreLocation;
using Foundation;
using UIKit;

namespace Metrica.Sample.Forms.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Init iOS AppMetrica directly
            var config = App.AppMetricaConfig();
            YandexMetricaIOS.YandexMetricaImplementation.Activate(config);

			var locationManager = new CLLocationManager();
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0)) {
				locationManager.RequestWhenInUseAuthorization();
			}

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

