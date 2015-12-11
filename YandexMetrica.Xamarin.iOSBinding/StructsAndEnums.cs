using System;
using ObjCRuntime;

namespace YandexMetricaIOS
{
	[Native]
	public enum YMMYandexMetricaEventErrorCode
	{
		InitializationError = 1000,
		InvalidName = 1001,
		JsonSerializationError = 1002
	}
}
