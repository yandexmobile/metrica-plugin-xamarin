/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using CoreFoundation;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace YandexMetricaIOS
{
	// typedef void (^YMMAppMetricaDeviceIDRetrievingBlock)(NSString * _Nullable, NSError * _Nullable);
	delegate void YMMAppMetricaDeviceIDRetrievingBlock ([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	[Static]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kYMMYandexMetricaErrorDomain;
		[Field ("kYMMYandexMetricaErrorDomain", "__Internal")]
		NSString kYMMYandexMetricaErrorDomain { get; }
	}

	// @interface YMMYandexMetrica : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetrica
	{
		// +(void)activateWithConfiguration:(YMMYandexMetricaConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("activateWithConfiguration:")]
		void ActivateWithConfiguration (YMMYandexMetricaConfiguration configuration);

		// +(void)reportEvent:(NSString * _Nonnull)message onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportEvent:onFailure:")]
		void ReportEvent (string message, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportEvent:(NSString * _Nonnull)message parameters:(NSDictionary * _Nullable)params onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportEvent:parameters:onFailure:")]
		void ReportEvent (string message, [NullAllowed] NSDictionary @params, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportError:(NSString * _Nonnull)message exception:(NSException * _Nullable)exception onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportError:exception:onFailure:")]
		void ReportError (string message, [NullAllowed] NSException exception, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportUserProfile:(YMMUserProfile * _Nonnull)userProfile onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportUserProfile:onFailure:")]
		void ReportUserProfile (YMMUserProfile userProfile, [NullAllowed] Action<NSError> onFailure);

		// +(void)reportRevenue:(YMMRevenueInfo * _Nonnull)revenueInfo onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Static]
		[Export ("reportRevenue:onFailure:")]
		void ReportRevenue (YMMRevenueInfo revenueInfo, [NullAllowed] Action<NSError> onFailure);

		// +(void)setUserProfileID:(NSString * _Nullable)userProfileID;
		[Static]
		[Export ("setUserProfileID:")]
		void SetUserProfileID ([NullAllowed] string userProfileID);

		// +(void)setStatisticsSending:(BOOL)enabled;
		[Static]
		[Export ("setStatisticsSending:")]
		void SetStatisticsSending (bool enabled);

		// +(void)setLocationTracking:(BOOL)enabled;
		[Static]
		[Export ("setLocationTracking:")]
		void SetLocationTracking (bool enabled);

		// +(void)setLocation:(CLLocation * _Nullable)location;
		[Static]
		[Export ("setLocation:")]
		void SetLocation ([NullAllowed] CLLocation location);

		// +(NSString * _Nonnull)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		string LibraryVersion { get; }

		// +(void)requestAppMetricaDeviceIDWithCompletionQueue:(dispatch_queue_t _Nullable)queue completionBlock:(YMMAppMetricaDeviceIDRetrievingBlock _Nonnull)block;
		[Static]
		[Export ("requestAppMetricaDeviceIDWithCompletionQueue:completionBlock:")]
		void RequestAppMetricaDeviceIDWithCompletionQueue ([NullAllowed] DispatchQueue queue, YMMAppMetricaDeviceIDRetrievingBlock block);

		// +(BOOL)handleOpenURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		// +(void)activateReporterWithConfiguration:(YMMReporterConfiguration * _Nonnull)configuration;
		[Static]
		[Export ("activateReporterWithConfiguration:")]
		void ActivateReporterWithConfiguration (YMMReporterConfiguration configuration);

		// +(id<YMMYandexMetricaReporting> _Nullable)reporterForApiKey:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("reporterForApiKey:")]
		[return: NullAllowed]
		YMMYandexMetricaReporting ReporterForApiKey (string apiKey);

		// +(void)reportReferralUrl:(NSURL * _Nonnull)url __attribute__((deprecated("Referral URL reporting is no longer available")));
		[Static]
		[Export ("reportReferralUrl:")]
		void ReportReferralUrl (NSUrl url);

		// +(void)sendEventsBuffer;
		[Static]
		[Export ("sendEventsBuffer")]
		void SendEventsBuffer ();

		// +(void)resumeSession;
		[Static]
		[Export ("resumeSession")]
		void ResumeSession ();

		// +(void)pauseSession;
		[Static]
		[Export ("pauseSession")]
		void PauseSession ();
	}

	// @interface YMMYandexMetricaConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaConfiguration
	{
		// -(instancetype _Nullable)initWithApiKey:(NSString * _Nonnull)apiKey;
		[Export ("initWithApiKey:")]
		IntPtr Constructor (string apiKey);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (assign, nonatomic) BOOL handleFirstActivationAsUpdate;
		[Export ("handleFirstActivationAsUpdate")]
		bool HandleFirstActivationAsUpdate { get; set; }

		// @property (assign, nonatomic) BOOL handleActivationAsSessionStart;
		[Export ("handleActivationAsSessionStart")]
		bool HandleActivationAsSessionStart { get; set; }

		// @property (assign, nonatomic) BOOL sessionsAutoTracking;
		[Export ("sessionsAutoTracking")]
		bool SessionsAutoTracking { get; set; }

		// @property (assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; set; }

		// @property (assign, nonatomic) BOOL locationTracking;
		[Export ("locationTracking")]
		bool LocationTracking { get; set; }

		// @property (nonatomic, strong) CLLocation * _Nullable location;
		[NullAllowed, Export ("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; set; }

		// @property (assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; set; }

		// @property (assign, nonatomic) BOOL crashReporting;
		[Export ("crashReporting")]
		bool CrashReporting { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable appVersion;
		[NullAllowed, Export ("appVersion")]
		string AppVersion { get; set; }

		// @property (assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; set; }

		// @property (copy, nonatomic) YMMYandexMetricaPreloadInfo * _Nullable preloadInfo;
		[NullAllowed, Export ("preloadInfo", ArgumentSemantic.Copy)]
		YMMYandexMetricaPreloadInfo PreloadInfo { get; set; }
	}

	// @interface YMMReporterConfiguration : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMReporterConfiguration : INSCopying, INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable apiKey;
		[NullAllowed, Export ("apiKey")]
		string ApiKey { get; }

		// @property (readonly, assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; }

		// @property (readonly, assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; }

		// @property (readonly, assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; }

		// -(instancetype _Nullable)initWithApiKey:(NSString * _Nonnull)apiKey;
		[Export ("initWithApiKey:")]
		IntPtr Constructor (string apiKey);
	}

	// @interface YMMMutableReporterConfiguration : YMMReporterConfiguration
	[BaseType (typeof(YMMReporterConfiguration))]
	[DisableDefaultCtor]
	interface YMMMutableReporterConfiguration
	{
		// @property (assign, nonatomic) BOOL statisticsSending;
		[Export ("statisticsSending")]
		bool StatisticsSending { get; set; }

		// @property (assign, nonatomic) NSUInteger sessionTimeout;
		[Export ("sessionTimeout")]
		nuint SessionTimeout { get; set; }

		// @property (assign, nonatomic) BOOL logs;
		[Export ("logs")]
		bool Logs { get; set; }
	}

	// @protocol YMMYandexMetricaReporting <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMYandexMetricaReporting
	{
		// @required -(void)reportEvent:(NSString * _Nonnull)name onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportEvent:onFailure:")]
		void ReportEvent (string name, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportEvent:(NSString * _Nonnull)name parameters:(NSDictionary * _Nullable)params onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportEvent:parameters:onFailure:")]
		void ReportEvent (string name, [NullAllowed] NSDictionary @params, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportError:(NSString * _Nonnull)name exception:(NSException * _Nullable)exception onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportError:exception:onFailure:")]
		void ReportError (string name, [NullAllowed] NSException exception, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportUserProfile:(YMMUserProfile * _Nonnull)userProfile onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportUserProfile:onFailure:")]
		void ReportUserProfile (YMMUserProfile userProfile, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)reportRevenue:(YMMRevenueInfo * _Nonnull)revenueInfo onFailure:(void (^ _Nullable)(NSError * _Nonnull))onFailure;
		[Abstract]
		[Export ("reportRevenue:onFailure:")]
		void ReportRevenue (YMMRevenueInfo revenueInfo, [NullAllowed] Action<NSError> onFailure);

		// @required -(void)setUserProfileID:(NSString * _Nullable)userProfileID;
		[Abstract]
		[Export ("setUserProfileID:")]
		void SetUserProfileID ([NullAllowed] string userProfileID);

		// @required -(void)resumeSession;
		[Abstract]
		[Export ("resumeSession")]
		void ResumeSession ();

		// @required -(void)pauseSession;
		[Abstract]
		[Export ("pauseSession")]
		void PauseSession ();

		// @required -(void)setStatisticsSending:(BOOL)enabled;
		[Abstract]
		[Export ("setStatisticsSending:")]
		void SetStatisticsSending (bool enabled);

		// @required -(void)sendEventsBuffer;
		[Abstract]
		[Export ("sendEventsBuffer")]
		void SendEventsBuffer ();
	}

	// @interface YMMYandexMetricaPreloadInfo : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMYandexMetricaPreloadInfo : INSCopying
	{
		// -(instancetype _Nullable)initWithTrackingIdentifier:(NSString * _Nonnull)trackingID;
		[Export ("initWithTrackingIdentifier:")]
		IntPtr Constructor (string trackingID);

		// -(void)setAdditionalInfo:(NSString * _Nonnull)info forKey:(NSString * _Nonnull)key;
		[Export ("setAdditionalInfo:forKey:")]
		void SetAdditionalInfo (string info, string key);
	}

	// @interface YMMUserProfileUpdate : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMUserProfileUpdate
	{
	}

	// @protocol YMMNameAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMNameAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue ([NullAllowed] string value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMNameAttribute { }

	// @protocol YMMGenderAttribute <NSObject>
	[Protocol, Model(Name = "YMMGenderAttributeNative")]
	[BaseType (typeof(NSObject))]
	interface YMMGenderAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(YMMGenderType)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (YMMGenderType value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMGenderAttribute { }

	// @protocol YMMBirthDateAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMBirthDateAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withAge:(NSUInteger)value;
		[Abstract]
		[Export ("withAge:")]
		YMMUserProfileUpdate WithAge (nuint value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year;
		[Abstract]
		[Export ("withYear:")]
		YMMUserProfileUpdate WithBirthDate(nuint year);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year month:(NSUInteger)month;
		[Abstract]
		[Export ("withYear:month:")]
		YMMUserProfileUpdate WithBirthDate(nuint year, nuint month);

		// @required -(YMMUserProfileUpdate * _Nonnull)withYear:(NSUInteger)year month:(NSUInteger)month day:(NSUInteger)day;
		[Abstract]
		[Export ("withYear:month:day:")]
		YMMUserProfileUpdate WithBirthDate(nuint year, nuint month, nuint day);

		// @required -(YMMUserProfileUpdate * _Nonnull)withDateComponents:(NSDateComponents * _Nonnull)dateComponents;
		[Abstract]
		[Export ("withDateComponents:")]
		YMMUserProfileUpdate WithDateComponents (NSDateComponents dateComponents);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMBirthDateAttribute { }

	// @protocol YMMNotificationsEnabledAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMNotificationsEnabledAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(BOOL)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (bool value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMNotificationsEnabledAttribute { }

	// @protocol YMMCustomStringAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMCustomStringAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue ([NullAllowed] string value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(NSString * _Nullable)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined ([NullAllowed] string value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMCustomStringAttribute {}

	// @protocol YMMCustomNumberAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMCustomNumberAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(double)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (double value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(double)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined (double value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMCustomNumberAttribute {}

	// @protocol YMMCustomCounterAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMCustomCounterAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withDelta:(double)value;
		[Abstract]
		[Export ("withDelta:")]
		YMMUserProfileUpdate WithDelta (double value);
	}

    interface IYMMCustomCounterAttribute {}

	// @protocol YMMCustomBoolAttribute <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YMMCustomBoolAttribute
	{
		// @required -(YMMUserProfileUpdate * _Nonnull)withValue:(BOOL)value;
		[Abstract]
		[Export ("withValue:")]
		YMMUserProfileUpdate WithValue (bool value);

		// @required -(YMMUserProfileUpdate * _Nonnull)withValueIfUndefined:(BOOL)value;
		[Abstract]
		[Export ("withValueIfUndefined:")]
		YMMUserProfileUpdate WithValueIfUndefined (bool value);

        // @required -(YMMUserProfileUpdate * _Nonnull)withValueReset;
        [Abstract]
        [Export ("withValueReset")]
        YMMUserProfileUpdate WithValueReset ();
	}

    interface IYMMCustomBoolAttribute {}

	// @interface YMMProfileAttribute : NSObject
	[BaseType (typeof(NSObject))]
	interface YMMProfileAttribute
	{
        // +(id<YMMNameAttribute> _Nonnull)name;
        [Static]
        [Export ("name")]
        IYMMNameAttribute Name ();

        // +(id<YMMGenderAttribute> _Nonnull)gender;
        [Static]
        [Export ("gender")]
        IYMMGenderAttribute Gender ();

        // +(id<YMMBirthDateAttribute> _Nonnull)birthDate;
        [Static]
        [Export ("birthDate")]
        IYMMBirthDateAttribute BirthDate ();

        // +(id<YMMNotificationsEnabledAttribute> _Nonnull)notificationsEnabled;
        [Static]
        [Export ("notificationsEnabled")]
        IYMMNotificationsEnabledAttribute NotificationsEnabled ();

		// +(id<YMMCustomStringAttribute> _Nonnull)customString:(NSString * _Nonnull)name;
		[Static]
		[Export ("customString:")]
		IYMMCustomStringAttribute CustomString (string name);

		// +(id<YMMCustomNumberAttribute> _Nonnull)customNumber:(NSString * _Nonnull)name;
		[Static]
		[Export ("customNumber:")]
		IYMMCustomNumberAttribute CustomNumber (string name);

		// +(id<YMMCustomCounterAttribute> _Nonnull)customCounter:(NSString * _Nonnull)name;
		[Static]
		[Export ("customCounter:")]
		IYMMCustomCounterAttribute CustomCounter (string name);

		// +(id<YMMCustomBoolAttribute> _Nonnull)customBool:(NSString * _Nonnull)name;
		[Static]
		[Export ("customBool:")]
		IYMMCustomBoolAttribute CustomBool (string name);
	}

	// @interface YMMUserProfile : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	interface YMMUserProfile : INSCopying, INSMutableCopying
	{
		// @property (readonly, copy, nonatomic) NSArray<YMMUserProfileUpdate *> * _Nonnull updates;
		[Export ("updates", ArgumentSemantic.Copy)]
		YMMUserProfileUpdate[] Updates { get; }

		// -(instancetype _Nonnull)initWithUpdates:(NSArray<YMMUserProfileUpdate *> * _Nonnull)updates;
		[Export ("initWithUpdates:")]
		IntPtr Constructor (YMMUserProfileUpdate[] updates);
	}

	// @interface YMMMutableUserProfile : YMMUserProfile
	[BaseType (typeof(YMMUserProfile))]
	interface YMMMutableUserProfile
	{
		// -(void)apply:(YMMUserProfileUpdate * _Nonnull)update;
		[Export ("apply:")]
		void Apply (YMMUserProfileUpdate update);

		// -(void)applyFromArray:(NSArray<YMMUserProfileUpdate *> * _Nonnull)updatesArray;
		[Export ("applyFromArray:")]
		void ApplyFromArray (YMMUserProfileUpdate[] updatesArray);
	}

	// @interface YMMRevenueInfo : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YMMRevenueInfo : INSCopying, INSMutableCopying
	{
		// @property (readonly, assign, nonatomic) double price __attribute__((deprecated("Use priceDecimal")));
		[Export ("price")]
		double Price { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable priceDecimal;
		[NullAllowed, Export ("priceDecimal", ArgumentSemantic.Strong)]
		NSDecimalNumber PriceDecimal { get; }

		// @property (readonly, copy, nonatomic) NSString * currency;
		[Export ("currency")]
		string Currency { get; }

		// @property (readonly, assign, nonatomic) NSUInteger quantity;
		[Export ("quantity")]
		nuint Quantity { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable productID;
		[NullAllowed, Export ("productID")]
		string ProductID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transactionID;
		[NullAllowed, Export ("transactionID")]
		string TransactionID { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable receiptData;
		[NullAllowed, Export ("receiptData", ArgumentSemantic.Copy)]
		NSData ReceiptData { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * _Nullable payload;
		[NullAllowed, Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary Payload { get; }

		// -(instancetype _Nonnull)initWithPrice:(double)price currency:(NSString * _Nonnull)currency __attribute__((deprecated("Use initWithPriceDecimal:currency:")));
		[Export ("initWithPrice:currency:")]
		IntPtr Constructor (double price, string currency);

		// -(instancetype _Nonnull)initWithPriceDecimal:(NSDecimalNumber * _Nonnull)priceDecimal currency:(NSString * _Nonnull)currency;
		[Export ("initWithPriceDecimal:currency:")]
		IntPtr Constructor (NSDecimalNumber priceDecimal, string currency);

		// -(instancetype _Nonnull)initWithPrice:(double)price currency:(NSString * _Nonnull)currency quantity:(NSUInteger)quantity productID:(NSString * _Nullable)productID transactionID:(NSString * _Nullable)transactionID receiptData:(NSData * _Nullable)receiptData payload:(NSDictionary * _Nullable)payload __attribute__((deprecated("Use initWithPriceDecimal:...")));
		[Export ("initWithPrice:currency:quantity:productID:transactionID:receiptData:payload:")]
		IntPtr Constructor (double price, string currency, nuint quantity, [NullAllowed] string productID, [NullAllowed] string transactionID, [NullAllowed] NSData receiptData, [NullAllowed] NSDictionary payload);

		// -(instancetype _Nonnull)initWithPriceDecimal:(NSDecimalNumber * _Nonnull)priceDecimal currency:(NSString * _Nonnull)currency quantity:(NSUInteger)quantity productID:(NSString * _Nullable)productID transactionID:(NSString * _Nullable)transactionID receiptData:(NSData * _Nullable)receiptData payload:(NSDictionary * _Nullable)payload;
		[Export ("initWithPriceDecimal:currency:quantity:productID:transactionID:receiptData:payload:")]
		IntPtr Constructor (NSDecimalNumber priceDecimal, string currency, nuint quantity, [NullAllowed] string productID, [NullAllowed] string transactionID, [NullAllowed] NSData receiptData, [NullAllowed] NSDictionary payload);
	}

	// @interface YMMMutableRevenueInfo : YMMRevenueInfo
	[BaseType (typeof(YMMRevenueInfo))]
	interface YMMMutableRevenueInfo
	{
		// @property (assign, nonatomic) NSUInteger quantity;
		[Export ("quantity")]
		nuint Quantity { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull productID;
		[Export ("productID")]
		string ProductID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull transactionID;
		[Export ("transactionID")]
		string TransactionID { get; set; }

		// @property (copy, nonatomic) NSData * _Nonnull receiptData;
		[Export ("receiptData", ArgumentSemantic.Copy)]
		NSData ReceiptData { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nonnull payload;
		[Export ("payload", ArgumentSemantic.Copy)]
		NSDictionary Payload { get; set; }
	}
}
