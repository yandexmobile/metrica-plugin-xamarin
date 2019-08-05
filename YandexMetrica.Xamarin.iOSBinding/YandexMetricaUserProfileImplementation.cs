/*
 * Version for Xamarin
 * © 2018-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using System;
using YandexMetricaPCL;

namespace YandexMetricaIOS
{
    class YandexMetricaAttributeImplementation : IYandexMetricaAttribute
    {
        public static void Init()
        {
            YandexMetricaAttribute.Implementation = new YandexMetricaAttributeImplementation();
        }

        public IYandexMetricaBirthDateAttribute BirthDate()
        {
            return new YandexMetricaBirthDateAttributeImplementation(YMMProfileAttribute.BirthDate());
        }

        public IYandexMetricaGenderAttribute Gender()
        {
            return new YandexMetricaGenderAttributeImplementation(YMMProfileAttribute.Gender());
        }

        public IYandexMetricaNameAttribute Name()
        {
            return new YandexMetricaNameAttributeImplementation(YMMProfileAttribute.Name());
        }

        public IYandexMetricaNotificationsEnabledAttribute NotificationsEnabled()
        {
            return new YandexMetricaNotificationsEnabledAttributeImplementation(YMMProfileAttribute.NotificationsEnabled());
        }

        public IYandexMetricaBooleanAttribute CustomBoolean(string key)
        {
            return new YandexMetricaBooleanAttributeImplementation(YMMProfileAttribute.CustomBool(key));
        }

        public IYandexMetricaCounterAttribute CustomCounter(string key)
        {
            return new YandexMetricaCounterAttributeImplementation(YMMProfileAttribute.CustomCounter(key));
        }

        public IYandexMetricaNumberAttribute CustomNumber(string key)
        {
            return new YandexMetricaNumberAttributeImplementation(YMMProfileAttribute.CustomNumber(key));
        }

        public IYandexMetricaStringAttribute CustomString(string key)
        {
            return new YandexMetricaStringAttributeImplementation(YMMProfileAttribute.CustomString(key));
        }
    }

    class YandexMetricaBirthDateAttributeImplementation : IYandexMetricaBirthDateAttribute
    {
        private readonly IYMMBirthDateAttribute _native;

        public YandexMetricaBirthDateAttributeImplementation(IYMMBirthDateAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithAge(int age)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithAge((nuint)age));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate((nuint)year));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate((nuint)year, (nuint)month));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month, int day)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate((nuint)year, (nuint)month, (nuint)day));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(DateTime date)
        {
            return WithBirthDate(date.Year, date.Month, date.Day);
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaGenderAttributeImplementation : IYandexMetricaGenderAttribute
    {
        private readonly IYMMGenderAttribute _native;

        public YandexMetricaGenderAttributeImplementation(IYMMGenderAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(YandexMetricaGender value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(GetIOSGender(value)));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }

        private YMMGenderType GetIOSGender(YandexMetricaGender gender)
        {
            switch (gender)
            {
                case YandexMetricaGender.FEMALE:
                    return YMMGenderType.Female;
                case YandexMetricaGender.MALE:
                    return YMMGenderType.Male;
                default:
                    return YMMGenderType.Other;
            }
        }
    }

    class YandexMetricaNameAttributeImplementation : IYandexMetricaNameAttribute
    {
        private readonly IYMMNameAttribute _native;

        public YandexMetricaNameAttributeImplementation(IYMMNameAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(string value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaNotificationsEnabledAttributeImplementation : IYandexMetricaNotificationsEnabledAttribute
    {
        private readonly IYMMNotificationsEnabledAttribute _native;

        public YandexMetricaNotificationsEnabledAttributeImplementation(IYMMNotificationsEnabledAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(bool value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaBooleanAttributeImplementation : IYandexMetricaBooleanAttribute
    {
        private readonly IYMMCustomBoolAttribute _native;

        public YandexMetricaBooleanAttributeImplementation(IYMMCustomBoolAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(bool value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(bool value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueIfUndefined(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaCounterAttributeImplementation : IYandexMetricaCounterAttribute
    {
        private readonly IYMMCustomCounterAttribute _native;

        public YandexMetricaCounterAttributeImplementation(IYMMCustomCounterAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithDelta(double value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithDelta(value));
        }
    }

    class YandexMetricaNumberAttributeImplementation : IYandexMetricaNumberAttribute
    {
        private readonly IYMMCustomNumberAttribute _native;

        public YandexMetricaNumberAttributeImplementation(IYMMCustomNumberAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(double value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(double value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueIfUndefined(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaStringAttributeImplementation : IYandexMetricaStringAttribute
    {
        private readonly IYMMCustomStringAttribute _native;

        public YandexMetricaStringAttributeImplementation(IYMMCustomStringAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(string value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueIfUndefined(string value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueIfUndefined(value));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }
    }

    class YandexMetricaUserProfileUpdateImplementation : IYandexMetricaUserProfileUpdate
    {
        private readonly YMMUserProfileUpdate _native;

        public YandexMetricaUserProfileUpdateImplementation(YMMUserProfileUpdate native)
        {
            _native = native;
        }

        public object Native
        {
            get
            {
                return _native;
            }
        }
    }
}
