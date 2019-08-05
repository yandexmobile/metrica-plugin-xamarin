/*
 * Version for Xamarin
 * © 2018-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;

namespace YandexMetricaPCL
{
    class YandexMetricaAttributeDummy : IYandexMetricaAttribute
    {
        public IYandexMetricaBirthDateAttribute BirthDate()
        {
            return new YandexMetricaBirthDateAttributeDummy();
        }

        public IYandexMetricaGenderAttribute Gender()
        {
            return new YandexMetricaGenderAttributeDummy();
        }

        public IYandexMetricaNameAttribute Name()
        {
            return new YandexMetricaNameAttributeDummy();
        }

        public IYandexMetricaNotificationsEnabledAttribute NotificationsEnabled()
        {
            return new YandexMetricaNotificationsEnabledAttributeDummy();
        }

        public IYandexMetricaBooleanAttribute CustomBoolean(string key)
        {
            return new YandexMetricaBooleanAttributeDummy();
        }

        public IYandexMetricaCounterAttribute CustomCounter(string key)
        {
            return new YandexMetricaCounterAttributeDummy();
        }

        public IYandexMetricaNumberAttribute CustomNumber(string key)
        {
            return new YandexMetricaNumberAttributeDummy();
        }

        public IYandexMetricaStringAttribute CustomString(string key)
        {
            return new YandexMetricaStringAttributeDummy();
        }
    }

    class YandexMetricaBirthDateAttributeDummy : IYandexMetricaBirthDateAttribute
    {
        public IYandexMetricaUserProfileUpdate WithAge(int age)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(DateTime date)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month, int day)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaGenderAttributeDummy : IYandexMetricaGenderAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(YandexMetricaGender value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaNameAttributeDummy : IYandexMetricaNameAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(string value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaNotificationsEnabledAttributeDummy : IYandexMetricaNotificationsEnabledAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(bool value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaBooleanAttributeDummy : IYandexMetricaBooleanAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(bool value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(bool value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaCounterAttributeDummy : IYandexMetricaCounterAttribute
    {
        public IYandexMetricaUserProfileUpdate WithDelta(double value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaNumberAttributeDummy : IYandexMetricaNumberAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(double value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(double value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaStringAttributeDummy : IYandexMetricaStringAttribute
    {
        public IYandexMetricaUserProfileUpdate WithValue(string value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(string value)
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateDummy();
        }
    }

    class YandexMetricaUserProfileUpdateDummy : IYandexMetricaUserProfileUpdate
    {
        public object Native
        {
            get
            {
                return default(object);
            }
        }
    }
}
