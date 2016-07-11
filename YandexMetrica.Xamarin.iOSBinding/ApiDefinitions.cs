using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;

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

		// +(void)activateWithConfiguration:(YMMYandexMetricaConfiguration *)configuration;
		[Static]
		[Export ("activateWithConfiguration:")]
		void ActivateWithConfiguration (YMMYandexMetricaConfiguration configuration);

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

		// +(BOOL)enableTrackingWithURLScheme:(NSURL *)urlScheme __attribute__((availability(ios, introduced=9_0))) __attribute__((availability(ios_app_extension, unavailable)));
		[Introduced(PlatformName.iOS,9,0)]
		[Static]
		[Export ("enableTrackingWithURLScheme:")]
		bool EnableTrackingWithURLScheme (NSUrl urlScheme);

		// +(BOOL)handleOpenURL:(NSURL *)url __attribute__((availability(ios, introduced=9_0))) __attribute__((availability(ios_app_extension, unavailable)));
		[Introduced(PlatformName.iOS,9,0)]
		[Static]
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);
	}

	// @interface YMMYandexMetricaDeprecatedOrUnavailable (YMMYandexMetrica)
	[Category]
	[BaseType (typeof(YMMYandexMetrica))]
	interface YMMYandexMetrica_YMMYandexMetricaDeprecatedOrUnavailable
	{
	}

	// @interface YMMYandexMetricaConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaConfiguration
	{
		// -(instancetype)initWithApiKey:(NSString *)apiKey;
		[Export ("initWithApiKey:")]
		IntPtr Constructor (string apiKey);

		// @property (readonly, copy, nonatomic) NSString * apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (assign, nonatomic) BOOL trackLocationEnabled;
		[Export ("trackLocationEnabled")]
		bool TrackLocationEnabled { get; set; }

		// @property (nonatomic, strong) CLLocation * location;
		[Export ("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; set; }

		// @property (assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; set; }

		// @property (assign, nonatomic) BOOL reportCrashesEnabled;
		[Export ("reportCrashesEnabled")]
		bool ReportCrashesEnabled { get; set; }

		// @property (copy, nonatomic) NSString * customAppVersion;
		[Export ("customAppVersion")]
		string CustomAppVersion { get; set; }

		// @property (assign, nonatomic) BOOL loggingEnabled;
		[Export ("loggingEnabled")]
		bool LoggingEnabled { get; set; }

		// @property (copy, nonatomic) YMMYandexMetricaPreloadInfo * preloadInfo;
		[Export ("preloadInfo", ArgumentSemantic.Copy)]
		YMMYandexMetricaPreloadInfo PreloadInfo { get; set; }
	}

	// @interface YMMYandexMetricaPreloadInfo : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaPreloadInfo : INSCopying
	{
		// -(instancetype _Nonnull)initWithTrackingIdentifier:(NSString * _Nonnull)trackingID;
		[Export ("initWithTrackingIdentifier:")]
		IntPtr Constructor (string trackingID);

		// -(void)setAdditionalInfo:(NSString * _Nonnull)info forKey:(NSString * _Nonnull)key;
		[Export ("setAdditionalInfo:forKey:")]
		void SetAdditionalInfo (string info, string key);
	}
}
