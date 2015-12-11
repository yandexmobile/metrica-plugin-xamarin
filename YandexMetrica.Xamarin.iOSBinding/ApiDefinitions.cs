using System;
using CoreLocation;
using Foundation;

namespace YandexMetricaIOS
{
	[Static]
	partial interface Constants
	{
		// extern NSString *const kYMMYandexMetricaErrorDomain;
		[Field ("kYMMYandexMetricaErrorDomain", "__Internal")]
		NSString kYMMYandexMetricaErrorDomain { get; }
	}

	// @interface YMMYandexMetrica : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetrica
	{
		// +(void)activateWithApiKey:(NSString *)apiKey;
		[Static]
		[Export ("activateWithApiKey:")]
		void ActivateWithApiKey (string apiKey);

		// +(void)reportEvent:(NSString *)message onFailure:(void (^)(NSError *))onFailure;
		[Static]
		[Export ("reportEvent:onFailure:")]
        void ReportEvent (string message, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportEvent:(NSString *)message parameters:(NSDictionary *)params onFailure:(void (^)(NSError *))onFailure;
		[Static]
		[Export ("reportEvent:parameters:onFailure:")]
        void ReportEvent (string message, NSDictionary @params, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportError:(NSString *)message exception:(NSException *)exception onFailure:(void (^)(NSError *))onFailure;
		[Static]
		[Export ("reportError:exception:onFailure:")]
        void ReportError (string message, NSException exception, [NullAllowed] Action<NSError> onFailure);

		// +(void)setTrackLocationEnabled:(BOOL)enabled;
		[Static]
		[Export ("setTrackLocationEnabled:")]
		void SetTrackLocationEnabled (bool enabled);

		// +(void)setLocation:(CLLocation *)location;
		[Static]
		[Export ("setLocation:")]
		void SetLocation (CLLocation location);

		// +(void)setSessionTimeout:(NSUInteger)sessionTimeoutSeconds;
		[Static]
		[Export ("setSessionTimeout:")]
		void SetSessionTimeout (nuint sessionTimeoutSeconds);

		// +(void)setReportCrashesEnabled:(BOOL)enabled;
		[Static]
		[Export ("setReportCrashesEnabled:")]
		void SetReportCrashesEnabled (bool enabled);

		// +(void)setCustomAppVersion:(NSString *)appVersion;
		[Static]
		[Export ("setCustomAppVersion:")]
		void SetCustomAppVersion (string appVersion);

		// +(void)setLoggingEnabled:(BOOL)isEnabled;
		[Static]
		[Export ("setLoggingEnabled:")]
		void SetLoggingEnabled (bool isEnabled);

		// +(void)setEnvironmentValue:(NSString *)value forKey:(NSString *)key;
		[Static]
		[Export ("setEnvironmentValue:forKey:")]
		void SetEnvironmentValue (string value, string key);

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		string LibraryVersion { get; }
	}

	// @interface YMMYandexMetricaDeprecatedOrUnavailable (YMMYandexMetrica)
	[Category]
	[BaseType (typeof(YMMYandexMetrica))]
	interface YMMYandexMetrica_YMMYandexMetricaDeprecatedOrUnavailable
	{
	}
}
