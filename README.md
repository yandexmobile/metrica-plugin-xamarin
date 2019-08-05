# AppMetrica Xamarin Plugin

## Documentation
Documentation available on [metrica official site] [DOCUMENTATION].

## Sample project
Sample projects (Xamarin Native and Xamarin Forms) to use is available at [samples/] [GitHubSAMPLE].

## AppStore submit notice
Starting from version 1.6.0 Yandex AppMetrica became also a tracking instrument and
uses Apple idfa to attribute installs. Because of that during submitting your
application to the AppStore you will be prompted with three checkboxes to state
your intentions for idfa usage.
As Yandex AppMetrica uses idfa for attributing app installations you need to select **Attribute this app installation to a previously served
advertisement**.

## Changelog

### Version 2.3.0
* Updated AppMetrica SDK versions (iOS 3.7.1, Android 3.6.4).

### Version 2.2.0
* Updated AppMetrica SDK versions (iOS 3.6.0, Android 3.6.0).

### Version 2.1.0
* Updated AppMetrica SDK versions (iOS 3.4.0, Android 3.4.0).
* Added properties in the config indicating that the first launch of the app is an update.
* Added a method to disable statistics sending.
* Added a method to retrieve the AppMetrica device ID (appmetrica_device_id).
* Added a method to force sending stored events from the buffer.
* Added methods for creating user profiles.
* Added revenue tracking.
* Support sending events with a nested dictionary.

### Version 2.0.0
* Updated AppMetrica SDK versions (iOS 3.1.2, Android 3.1.0).
* Changed the SDK to meet the requirements of the Apple App Store Review Team. Update the plugin to avoid any issues during the App Store moderation process.
* Changed API methods.
* Added a method for getting the configuration of the AppMetrica Push Xamarin plugin.
* Fixed an [issue](https://github.com/yandexmobile/metrica-plugin-xamarin/issues/5) when using custom Application class

### Version 1.1.0
* Updated AppMetrica libs: iOS 2.6.5 and Android 2.6.0.
* Updated script for iOS AppMetrica lib updating.

### Version 1.0.0
* Updated AppMetrica libs: iOS 2.5.1 and Android 2.4.2.
* Released [NuGet package] [NuGetPackage].

### Version 0.1.0
* Implemented bindings for AppMetrica iOS (v2.1.1) and AppMetrica Android (v2.23).
* Implemented PCL wrapper for bindings.
* Provided samples for Xamarin Native and Xamarin Forms (iOS and Android).

## License
License agreement on use of Yandex AppMetrica is available at [EULA site] [LICENSE]


[LICENSE]: https://yandex.com/legal/appmetrica_sdk_agreement/ "Yandex AppMetrica agreement"
[DOCUMENTATION]: https://appmetrica.yandex.ru/docs/mobile-sdk-dg/concepts/xamarin-plugin.html "Yandex AppMetrica Xamarin Plugin documentation"
[GitHubSAMPLE]: https://github.com/yandexmobile/metrica-plugin-xamarin/tree/master/samples "Samples from reository"
[NuGetPackage]: https://www.nuget.org/packages/Yandex.Metrica.Xamarin/ "NuGet package"
