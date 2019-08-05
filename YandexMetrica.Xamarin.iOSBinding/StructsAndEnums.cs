/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using ObjCRuntime;

namespace YandexMetricaIOS
{
	[Native]
	public enum YMMYandexMetricaEventErrorCode : int
	{
		InitializationError = 1000,
		InvalidName = 1001,
		JsonSerializationError = 1002,
		InvalidRevenueInfo = 1003,
		EmptyUserProfile = 1004,
		NoCrashLibrary = 1005
	}

	[Native]
	public enum YMMGenderType : ulong
	{
		Male,
		Female,
		Other
	}
}
