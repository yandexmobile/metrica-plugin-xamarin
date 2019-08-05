/*
 * Version for Xamarin
 * © 2018-2019 YANDEX
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * https://yandex.com/legal/appmetrica_sdk_agreement/
 */

using AndroidAttribute = Com.Yandex.Metrica.Profile.Attribute;
using AndroidBirthDateAttribute = Com.Yandex.Metrica.Profile.BirthDateAttribute;
using AndroidGenderAttribute = Com.Yandex.Metrica.Profile.GenderAttribute;
using AndroidNameAttribute = Com.Yandex.Metrica.Profile.NameAttribute;
using AndroidNotificationsEnabledAttribute = Com.Yandex.Metrica.Profile.NotificationsEnabledAttribute;
using AndroidCounterAttribute = Com.Yandex.Metrica.Profile.CounterAttribute;
using AndroidBooleanAttribute = Com.Yandex.Metrica.Profile.BooleanAttribute;
using AndroidNumberAttribute = Com.Yandex.Metrica.Profile.NumberAttribute;
using AndroidStringAttribute = Com.Yandex.Metrica.Profile.StringAttribute;
using AndroidUserProfileUpdate = Com.Yandex.Metrica.Profile.UserProfileUpdate;
using System;
using YandexMetricaPCL;

namespace YandexMetricaAndroid
{
    class YandexMetricaAttributeImplementation : IYandexMetricaAttribute
    {
        public static void Init()
        {
            YandexMetricaAttribute.Implementation = new YandexMetricaAttributeImplementation();
        }

        public IYandexMetricaBirthDateAttribute BirthDate()
        {
            return new YandexMetricaBirthDateAttributeImplementation(AndroidAttribute.BirthDate());
        }

        public IYandexMetricaGenderAttribute Gender()
        {
            return new YandexMetricaGenderAttributeImplementation(AndroidAttribute.Gender());
        }

        public IYandexMetricaNameAttribute Name()
        {
            return new YandexMetricaNameAttributeImplementation(AndroidAttribute.Name());
        }

        public IYandexMetricaNotificationsEnabledAttribute NotificationsEnabled()
        {
            return new YandexMetricaNotificationsEnabledAttributeImplementation(AndroidAttribute.NotificationsEnabled());
        }

        public IYandexMetricaBooleanAttribute CustomBoolean(string key)
        {
            return new YandexMetricaBooleanAttributeImplementation(AndroidAttribute.CustomBoolean(key));
        }

        public IYandexMetricaCounterAttribute CustomCounter(string key)
        {
            return new YandexMetricaCounterAttributeImplementation(AndroidAttribute.CustomCounter(key));
        }

        public IYandexMetricaNumberAttribute CustomNumber(string key)
        {
            return new YandexMetricaNumberAttributeImplementation(AndroidAttribute.CustomNumber(key));
        }

        public IYandexMetricaStringAttribute CustomString(string key)
        {
            return new YandexMetricaStringAttributeImplementation(AndroidAttribute.CustomString(key));
        }
    }

    class YandexMetricaBirthDateAttributeImplementation : IYandexMetricaBirthDateAttribute
    {
        private readonly AndroidBirthDateAttribute _native;

        public YandexMetricaBirthDateAttributeImplementation(AndroidBirthDateAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithAge(int age)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithAge(age));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate(year));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate(year, month));
        }

        public IYandexMetricaUserProfileUpdate WithBirthDate(int year, int month, int day)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithBirthDate(year, month, day));
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
        private readonly AndroidGenderAttribute _native;

        public YandexMetricaGenderAttributeImplementation(AndroidGenderAttribute native)
        {
            _native = native;
        }

        public IYandexMetricaUserProfileUpdate WithValue(YandexMetricaGender value)
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValue(GetAndroidGender(value)));
        }

        public IYandexMetricaUserProfileUpdate WithValueReset()
        {
            return new YandexMetricaUserProfileUpdateImplementation(_native.WithValueReset());
        }

        private AndroidGenderAttribute.Gender GetAndroidGender(YandexMetricaGender gender)
        {
            switch (gender)
            {
                case YandexMetricaGender.FEMALE:
                    return AndroidGenderAttribute.Gender.Female;
                case YandexMetricaGender.MALE:
                    return AndroidGenderAttribute.Gender.Male;
                default:
                    return AndroidGenderAttribute.Gender.Other;
            }
        }
    }

    class YandexMetricaNameAttributeImplementation : IYandexMetricaNameAttribute
    {
        private readonly AndroidNameAttribute _native;

        public YandexMetricaNameAttributeImplementation(AndroidNameAttribute native)
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
        private readonly AndroidNotificationsEnabledAttribute _native;

        public YandexMetricaNotificationsEnabledAttributeImplementation(AndroidNotificationsEnabledAttribute native)
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
        private readonly AndroidBooleanAttribute _native;

        public YandexMetricaBooleanAttributeImplementation(AndroidBooleanAttribute native)
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
        private readonly AndroidCounterAttribute _native;

        public YandexMetricaCounterAttributeImplementation(AndroidCounterAttribute native)
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
        private readonly AndroidNumberAttribute _native;

        public YandexMetricaNumberAttributeImplementation(AndroidNumberAttribute native)
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
        private readonly AndroidStringAttribute _native;

        public YandexMetricaStringAttributeImplementation(AndroidStringAttribute native)
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
        private readonly AndroidUserProfileUpdate _native;

        public YandexMetricaUserProfileUpdateImplementation(AndroidUserProfileUpdate native)
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
