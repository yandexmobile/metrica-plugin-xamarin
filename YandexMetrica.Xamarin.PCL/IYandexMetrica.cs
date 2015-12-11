using System;
using System.Collections.Generic;

namespace YandexMetricaPCL
{
    public interface IYandexMetrica
    {
        /// <summary>
        /// <para>Reports the event.</para>
        /// 
        /// <para>Android: public static void reportEvent(final String eventName)</para>
        /// <para>iOS: +(void)reportEvent:(NSString *)message onFailure:(void (^)(NSError *))onFailure</para>
        /// </summary>
        /// <param name="message">Report message.</param>
        void ReportEvent(string message);

        /// <summary>
        /// <para>Reports the event.</para>
        /// 
        /// <para>Android: public static void reportEvent(final String eventName, final Map&lt;String, Object&gt; attributes)</para>
        /// <para>iOS: +(void)reportEvent:(NSString *)message parameters:(NSDictionary *)params onFailure:(void (^)(NSError *))onFailure</para>
        /// </summary>
        /// <param name="message">Report message.</param>
        /// <param name="parameters">Custom parameters.</param>
        void ReportEvent (string message, IDictionary<string, string> parameters);

        /// <summary>
        /// <para>Reports the error.</para>
        /// 
        /// <para>Android: public static void reportError(final String message, final Throwable error)</para>
        /// <para>iOS: +(void)reportError:(NSString *)message exception:(NSException *)exception onFailure:(void (^)(NSError *))onFailure</para>
        /// </summary>
        /// <param name="message">Report message.</param>
        /// <param name="exception">Exception.</param>
        void ReportError (string message, Exception exception);

        /// <summary>
        /// <para>Sets the track location enabled.</para>
        /// 
        /// <para>Android: public static void setTrackLocationEnabled(final boolean enabled)</para>
        /// <para>iOS: +(void)setTrackLocationEnabled:(BOOL)enabled</para>
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> enabled.</param>
        void SetTrackLocationEnabled (bool enabled);

        /// <summary>
        /// <para>Sets the location.</para>
        /// 
        /// <para>Android: public static void setLocation(final Location location)</para>
        /// <para>iOS: +(void)setLocation:(CLLocation *)location</para>
        /// </summary>
        /// <param name="latitude">Location latitude.</param>
        /// <param name="longitude">Location longitude.</param>
        void SetLocation (float latitude, float longitude);

        /// <summary>
        /// <para>Sets the session timeout.</para>
        /// 
        /// <para>Android: public static void setSessionTimeout(final int sessionTimeout)</para>
        /// <para>iOS: +(void)setSessionTimeout:(NSUInteger)sessionTimeoutSeconds</para>
        /// </summary>
        /// <param name="sessionTimeoutSeconds">Session timeout seconds.</param>
        void SetSessionTimeout (uint sessionTimeoutSeconds);

        /// <summary>
        /// <para>Sets the report crashes enabled.</para>
        /// 
        /// <para>Android: public static void setReportCrashesEnabled(final boolean enabled)</para>
        /// <para>iOS: +(void)setReportCrashesEnabled:(BOOL)enabled</para>
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> enabled.</param>
        void SetReportCrashesEnabled (bool enabled);

        /// <summary>
        /// <para>Sets the custom app version.</para>
        /// 
        /// <para>Android: public static void setCustomAppVersion(final String appVersion)</para>
        /// <para>iOS: +(void)setCustomAppVersion:(NSString *)appVersion</para>
        /// </summary>
        /// <param name="appVersion">App version.</param>
        void SetCustomAppVersion (string appVersion);

        /// <summary>
        /// <para>Sets the logging enabled.</para>
        /// 
        /// <para>Android: public static void setLogEnabled()</para>
        /// <para>iOS: +(void)setLoggingEnabled:(BOOL)isEnabled</para>
        /// </summary>
        void SetLoggingEnabled ();

        /// <summary>
        /// <para>Sets the environment value.</para>
        /// 
        /// <para>Android: public static void setEnvironmentValue(@NonNull final String key, @Nullable final String value)</para>
        /// <para>iOS: +(void)setEnvironmentValue:(NSString *)value forKey:(NSString *)key</para>
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        void SetEnvironmentValue (string key, string value);

        /// <summary>
        /// <para>Gets or sets a value indicating whether AppMetrica collect installed apps.</para>
        /// 
        /// <para>Android: public static void setCollectInstalledApps(final boolean collect)</para>
        /// <para>iOS: Not implemented</para>
        /// </summary>
        /// <value><c>true</c> if collect installed apps; otherwise, <c>false</c>.</value>
        bool CollectInstalledApps { get; set; }

        /// <summary>
        /// <para>Gets the library version.</para>
        /// 
        /// <para>Android: public static String getLibraryVersion()</para>
        /// <para>iOS: +(NSString *)libraryVersion</para>
        /// </summary>
        /// <value>The library version.</value>
        string LibraryVersion { get; }

        /// <summary>
        /// <para>Gets the library API level.</para>
        /// 
        /// <para>Android: public static int getLibraryApiLevel()</para>
        /// <para>iOS: Not implemented</para>
        /// </summary>
        /// <value>The library API level.</value>
        int LibraryApiLevel { get; }
    }
}
