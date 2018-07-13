using ObjCRuntime;

[assembly: LinkWith ("libYandexMobileMetrica-3.1.2.a",
    SmartLink = true, ForceLoad = true,
    Frameworks = "SystemConfiguration Security UIKit Foundation CoreTelephony CoreLocation CoreGraphics AdSupport",
	WeakFrameworks = "iAd",
    LinkerFlags = "-lz -lc++ -lsqlite3 -ObjC")]