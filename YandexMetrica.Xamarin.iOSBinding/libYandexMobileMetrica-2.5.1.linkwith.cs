using ObjCRuntime;

[assembly: LinkWith ("libYandexMobileMetrica-2.5.1.a",
    SmartLink = true, ForceLoad = true,
    Frameworks = "SystemConfiguration Security UIKit Foundation CoreTelephony CoreLocation CoreGraphics AdSupport",
	WeakFrameworks = "SafariServices",
    LinkerFlags = "-lz -lc++ -lsqlite3 -ObjC")]