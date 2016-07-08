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
As YandexMetrica uses idfa for attributing app installations you need to select **Attribute this app installation to a previously served
advertisement**.

## Changelog

### Version 0.2.0
* Updated Metrica libs: iOS 2.5.1 and Android 2.4.2.

### Version 0.1.0
* Implemented bindings for AppMetrica iOS (v2.1.1) and AppMetrica Android (v2.23).
* Implemented PCL wrapper for bindings.
* Provided samples for Xamarin Native and Xamarin Forms (iOS and Android).

## License
License agreement on use of Yandex AppMetrica for Apps SDK is available at [EULA site] [LICENSE]


[LICENSE]: https://yandex.com/legal/metrica_termsofuse/ "Yandex AppMetrica agreement"
[DOCUMENTATION]: https://tech.yandex.ru/metrica-mobile-sdk/doc/mobile-sdk-dg/concepts/xamarin-plugin-docpage/ "Yandex AppMetrica Xamarin Plugin documentation"
[GitHubSAMPLE]: https://github.com/yandexmobile/metrica-plugin-xamarin/tree/master/samples "Samples from reository"
