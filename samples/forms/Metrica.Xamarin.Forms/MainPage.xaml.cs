/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using YandexMetricaPCL;

namespace Metrica.Sample.Forms
{
	public partial class MainPage : ContentPage
	{
		private int ClicksCount { get; set; }
		private int ErrorsCount { get; set; }

		public MainPage ()
		{
			InitializeComponent ();

			ClicksCount = 0;
			ErrorsCount = 0;
		}

		public void OnEventClicked (object sender, EventArgs args)
		{
			++ClicksCount;

			var dict = new Dictionary<string, string>{
				{ "click", ClicksCount.ToString() },
			};
			YandexMetrica.Implementation.ReportEvent("Click from Forms", dict);

			clickButton.Text = string.Format("{0} clicks logged", ClicksCount);
		}

		public void OnErrorClicked (object sender, EventArgs args)
		{
			++ErrorsCount;

			try {
				throw new Exception (string.Format ("I'm exception #{0}", ErrorsCount));
			} catch (Exception ex) {
				YandexMetrica.Implementation.ReportError ("Error from Forms", ex);
			}

			errorButton.Text = string.Format ("{0} errors logged", ErrorsCount);
		}

		public void OnCrashClicked (object sender, EventArgs args)
		{
			throw new NullReferenceException ();
		}

		public void OnSetMinskLocation(object sender, EventArgs args)
		{
			SetLocation(53.890651, 27.525408);
		}

		public void OnSetMoscowLocation(object sender, EventArgs args)
		{
			SetLocation(55.734417, 37.588029);
		}

		private void SetLocation(double latitude, double longitude)
		{
			YandexMetrica.Implementation.SetLocation(new Coordinates { Latitude = latitude, Longitude = longitude });
			DisplayAlert("Location", string.Format("{0} {1}", latitude, longitude), "OK");
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

