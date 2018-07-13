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
