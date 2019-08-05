/*
 * Version for Xamarin
 * © 2015-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections;

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
        void ReportEvent (string message, IDictionary parameters);

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
        /// <para>Initiates forced sending of all stored events from the buffer.</para>
        /// 
        /// <para>Android: public static void sendEventsBuffer()</para>
        /// <para>iOS: +(void)sendEventsBuffer</para>
        /// </summary>
        void SendEventsBuffer();

        /// <summary>
        /// <para>Enables/disables statistics sending to the AppMetrica server. By default, the sending is enabled.</para>
        /// 
        /// <para>Android: public static void setStatisticsSending(Context context, boolean enabled)</para>
        /// <para>iOS: +(void)setStatisticsSending:(BOOL)enabled</para>
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> enabled.</param>
        void SetStatisticsSending(bool enabled);

        /// <summary>
        /// <para>Sends information about the purchase.</para>
        /// 
        /// <para>Android: public static void reportRevenue(Revenue revenue)</para>
        /// <para>iOS: +(void)reportRevenue:(YMMRevenueInfo *)revenueInfo onFailure:(void (^)(NSError *))onFailure</para>
        /// </summary>
        void ReportRevenue(YandexAppMetricaRevenue revenue);

        /// <summary>
        /// <para>Retrieves unique AppMetrica device identifier. It is used to identify a device in the statistics.</para>
        /// 
        /// <para>Android: public static void requestAppMetricaDeviceID(AppMetricaDeviceIDListener listener)</para>
        /// <para>iOS: +(void)requestAppMetricaDeviceIDWithCompletionQueue:(dispatch_queue_t)queue completionBlock:(YMMAppMetricaDeviceIDRetrievingBlock)block</para>
        /// </summary>
        /// <param name="action">Action will be dispatched upon identifier becoming available or in a case of error.</param>
        void RequestAppMetricaDeviceID(Action<String, YandexAppMetricaRequestDeviceIDError?> action);

        /// <summary>
        /// <para>Sets the ID of the user profile.</para>
        /// 
        /// <para>Android: public static void setUserProfileID(String userProfileID)</para>
        /// <para>iOS: +(void)setUserProfileID:(NSString *)userProfileID</para>
        /// </summary>
        /// <param name="userProfileID">The custom user profile ID.</param>
        void SetUserProfileID(string userProfileID);

        /// <summary>
        /// <para>Reports the user profile.</para>
        /// 
        /// <para>Android: public static void reportUserProfile(UserProfile profile)</para>
        /// <para>iOS: +(void)reportUserProfile:(YMMUserProfile *)userProfile onFailure:(nullable void (^)(NSError *error))onFailure</para>
        /// </summary>
        /// <param name="userProfile">The YandexMetricaUserProfile object. Contains user profile information.</param>
        void ReportUserProfile(YandexMetricaUserProfile userProfile);

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
