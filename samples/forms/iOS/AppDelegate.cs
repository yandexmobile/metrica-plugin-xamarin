using System;
using System.Collections.Generic;
using System.Linq;

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

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

