/*
 * Version for Xamarin
 * © 2018-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using System.Collections.Generic;

namespace YandexMetricaPCL
{
    public enum YandexMetricaGender
    {
        MALE,
        FEMALE,
        OTHER
    }

    public class YandexMetricaUserProfile
    {
        private readonly List<IYandexMetricaUserProfileUpdate> _userProfileUpdates = new List<IYandexMetricaUserProfileUpdate>();
        public List<IYandexMetricaUserProfileUpdate> UserProfileUpdates
        {
            get
            {
                return new List<IYandexMetricaUserProfileUpdate>(_userProfileUpdates);
            }
        }

        public YandexMetricaUserProfile Apply(IYandexMetricaUserProfileUpdate userProfileUpdate)
        {
            _userProfileUpdates.Add(userProfileUpdate);
            return this;
        }

        public YandexMetricaUserProfile ApplyFromArray(List<IYandexMetricaUserProfileUpdate> userProfileUpdates)
        {
            _userProfileUpdates.AddRange(userProfileUpdates);
            return this;
        }
    }

    public interface IYandexMetricaAttribute
    {
        IYandexMetricaBirthDateAttribute BirthDate();

        IYandexMetricaGenderAttribute Gender();

        IYandexMetricaNameAttribute Name();

        IYandexMetricaNotificationsEnabledAttribute NotificationsEnabled();

        IYandexMetricaBooleanAttribute CustomBoolean(string key);

        IYandexMetricaCounterAttribute CustomCounter(string key);

        IYandexMetricaNumberAttribute CustomNumber(string key);

        IYandexMetricaStringAttribute CustomString(string key);
    }

    public interface IYandexMetricaBirthDateAttribute
    {
        IYandexMetricaUserProfileUpdate WithAge(int age);

        IYandexMetricaUserProfileUpdate WithBirthDate(DateTime date);

        IYandexMetricaUserProfileUpdate WithBirthDate(int year);

        IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month);

        IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month, int day);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaGenderAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(YandexMetricaGender value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaNameAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(string value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaNotificationsEnabledAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(bool value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaBooleanAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(bool value);

        IYandexMetricaUserProfileUpdate WithValueIfUndefined(bool value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaCounterAttribute
    {
        IYandexMetricaUserProfileUpdate WithDelta(double value);
    }

    public interface IYandexMetricaNumberAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(double value);

        IYandexMetricaUserProfileUpdate WithValueIfUndefined(double value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaStringAttribute
    {
        IYandexMetricaUserProfileUpdate WithValue(string value);

        IYandexMetricaUserProfileUpdate WithValueIfUndefined(string value);

        IYandexMetricaUserProfileUpdate WithValueReset();
    }

    public interface IYandexMetricaUserProfileUpdate
    {
        object Native { get; }
    }

    public static class YandexMetricaAttribute
    {
        public static IYandexMetricaAttribute Implementation { private get; set; }

        static YandexMetricaAttribute() 
        {
            Implementation = new YandexMetricaAttributeDummy();
        }

        public static IYandexMetricaBirthDateAttribute BirthDate()
        {
            return Implementation.BirthDate();
        }

        public static IYandexMetricaGenderAttribute Gender()
        {
            return Implementation.Gender();
        }

        public static IYandexMetricaNameAttribute Name()
        {
            return Implementation.Name();
        }

        public static IYandexMetricaNotificationsEnabledAttribute NotificationsEnabled()
        {
            return Implementation.NotificationsEnabled();
        }

        public static IYandexMetricaBooleanAttribute CustomBoolean(string key)
        {
            return Implementation.CustomBoolean(key);
        }

        public static IYandexMetricaCounterAttribute CustomCounter(string key)
        {
            return Implementation.CustomCounter(key);
        }

        public static IYandexMetricaNumberAttribute CustomNumber(string key)
        {
            return Implementation.CustomNumber(key);
        }

        public static IYandexMetricaStringAttribute CustomString(string key)
        {
            return Implementation.CustomString(key);
        }
    }
}
