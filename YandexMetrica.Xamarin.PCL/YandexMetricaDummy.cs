using System;

namespace YandexMetricaPCL
{
    /// <summary>
    /// AppMetrica empty implementation.
    /// </summary>
    public class YandexMetricaDummy : IYandexMetrica
    {
        public void ReportEvent(string message) { }

        public void ReportEvent(string message, System.Collections.Generic.IDictionary<string, string> parameters) { } 

        public void ReportError(string message, Exception exception) { }

        public void SetTrackLocationEnabled(bool enabled) { }

        public void SetLocation(Coordinates coordinates) { }

        public void SetSessionTimeout(uint sessionTimeoutSeconds) { }

        public void SetReportCrashesEnabled(bool enabled) { }

        public void SetCustomAppVersion(string appVersion) { }

        public void SetLoggingEnabled() { }

        public void SetEnvironmentValue(string key, string value) { }

        public bool CollectInstalledApps { get { return false; } set { } }

        public string LibraryVersion { get { return default(string); } }

        public int LibraryApiLevel { get { return default(int); } }
    }
}

