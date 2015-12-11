// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Metrica.Xamarin.CrossPlatform.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LogClickButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LogErrorButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (LogClickButton != null) {
				LogClickButton.Dispose ();
				LogClickButton = null;
			}
			if (LogErrorButton != null) {
				LogErrorButton.Dispose ();
				LogErrorButton = null;
			}
		}
	}
}
