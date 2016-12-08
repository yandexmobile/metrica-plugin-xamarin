using ObjCRuntime;

[assembly: LinkWith ("libYandexMobileMetrica-2.6.5.a",
    SmartLink = true, ForceLoad = true,
    Frameworks = "SystemConfiguration Security UIKit Foundation CoreTelephony CoreLocation CoreGraphics AdSupport",
	WeakFrameworks = "SafariServices",
    LinkerFlags = "-lz -lc++ -lsqlite3 -ObjC")]