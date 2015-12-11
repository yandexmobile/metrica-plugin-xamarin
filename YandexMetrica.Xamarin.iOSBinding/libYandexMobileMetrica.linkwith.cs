using ObjCRuntime;

[assembly: LinkWith ("libYandexMobileMetrica.a", 
    SmartLink = true, ForceLoad = true, 
    Frameworks = "SystemConfiguration Security UIKit Foundation CoreTelephony CoreLocation CoreGraphics AdSupport", 
    LinkerFlags = "-lz -lc++ -lsqlite3 -ObjC")]