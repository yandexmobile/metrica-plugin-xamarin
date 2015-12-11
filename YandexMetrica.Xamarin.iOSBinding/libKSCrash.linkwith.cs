using ObjCRuntime;

[assembly: LinkWith ("libKSCrash.a", SmartLink = true, ForceLoad = true, LinkerFlags = "-lc++ -lz")]
