/*
 * Version for Xamarin
 * © 2015-2017 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;

namespace YandexMetricaPCL
{
    public delegate void ConfigUpdateHandler(YandexMetricaConfig config);

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
        /// <para>Android: public static void setLocationTracking(final boolean enabled)</para>
        /// <para>iOS: +(void)setLocationTracking:(BOOL)enabled</para>
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> enabled.</param>
        void SetLocationTracking (bool enabled);

        /// <summary>
        /// <para>Sets the location.</para>
        /// 
        /// <para>Android: public static void setLocation(final Location location)</para>
        /// <para>iOS: +(void)setLocation:(CLLocation *)location</para>
        /// </summary>
        /// <param name="coordinates">Location coordinates(latitude and longitude).</param>
        void SetLocation (Coordinates coordinates);

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
