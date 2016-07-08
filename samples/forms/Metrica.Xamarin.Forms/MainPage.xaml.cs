using System;
using System.Collections.Generic;

using Xamarin.Forms;
using YandexMetricaPCL;

namespace Metrica.Sample.Forms
{
	public partial class MainPage : ContentPage
	{
		static int clicksCount = 0;
		static int errorsCount = 0;

		public MainPage ()
		{
			InitializeComponent ();

			collectAppsSwitch.IsToggled = YandexMetrica.Implementation.CollectInstalledApps;
		}

		public void OnEventClicked (object sender, EventArgs args)
		{
			++clicksCount;

			var dict = new Dictionary<string, string>{
				{ "click", clicksCount.ToString() },
			};
			YandexMetrica.Implementation.ReportEvent("Click from Forms", dict);

			clickButton.Text = string.Format("{0} clicks logged", clicksCount);
		}

		public void OnErrorClicked (object sender, EventArgs args)
		{
			++errorsCount;

			try {
				throw new Exception (string.Format ("I'm exception #{0}", errorsCount));
			} catch (Exception ex) {
				YandexMetrica.Implementation.ReportError ("Error from Forms", ex);
			}

			errorButton.Text = string.Format ("{0} errors logged", errorsCount);
		}

		public void OnCrashClicked (object sender, EventArgs args)
		{
			throw new NullReferenceException ();
		}

		public void OnSetMinskLocation(object sender, EventArgs args)
		{
			double latitude = 53.890651;
			double longitude = 27.525408;
			YandexMetrica.Implementation.SetLocation(new Coordinates { Latitude = latitude, Longitude = longitude});
			DisplayAlert ("Location", string.Format("{0} {1}", latitude, longitude), "OK");
		}

		public void OnSetMoskowLocation(object sender, EventArgs args)
		{
			double latitude = 55.734417;
			double longitude = 37.588029;
			YandexMetrica.Implementation.SetLocation(new Coordinates { Latitude = latitude, Longitude = longitude});
			DisplayAlert ("Location", string.Format("{0} {1}", latitude, longitude), "OK");
		}

		public void OnSetAppVersion(object sender, EventArgs args)
		{
			string appVersion = appVersionEntry.Text;
			YandexMetrica.Implementation.SetCustomAppVersion (appVersion);
			DisplayAlert ("App Version", appVersion, "OK");
		}

		public void OnSetSessionTimeout(object sender, EventArgs args)
		{
			uint timeout = 10;
			if (uint.TryParse (sessionTimeoutEntry.Text, out timeout)) {
				YandexMetrica.Implementation.SetSessionTimeout (timeout);
				DisplayAlert ("Session Timeout", timeout.ToString (), "OK");
			} 
		}

		public void OnChangeReportCrashes(object sender, EventArgs args)
		{
			YandexMetrica.Implementation.SetReportCrashesEnabled (reportCrashesSwitch.IsToggled);
		}

		public void OnChangeCollectApps(object sender, EventArgs args)
		{
			if (collectAppsSwitch != null) {
				YandexMetrica.Implementation.CollectInstalledApps = collectAppsSwitch.IsToggled;
			}
		}

		public void OnLibraryVersionClicked (object sender, EventArgs args)
		{
			DisplayAlert ("Library Version", YandexMetrica.Implementation.LibraryVersion, "OK");
		}

		public void OnLibraryAPILevelClicked (object sender, EventArgs args)
		{
			DisplayAlert ("Library API Level", YandexMetrica.Implementation.LibraryApiLevel.ToString(), "OK");
		}
	}
}

