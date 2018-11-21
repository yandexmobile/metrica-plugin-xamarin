#!/bin/bash

set -e

# Download Objective Sharpie first:
DOWNLOAD_LINK="https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/objective_sharpie/"

sharpie --version 2>/dev/null || ( echo "Install Sharpie first: $DOWNLOAD_LINK" && false )

SDK=$(sharpie xcode -sdks | awk '/sdk: iphoneos.*/{print $2}' | head -n 1)
if [ -z "$SDK" ]; then
    echo "No SDK found"
    exit 1
fi

echo "SDK used: ${SDK}"
sharpie bind -output ./ -namespace YandexMetricaIOS -sdk "${SDK}" -scope Headers/YandexMobileMetrica Headers/YandexMobileMetrica/YandexMobileMetrica.h
