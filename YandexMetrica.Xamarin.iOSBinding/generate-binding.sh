#!/bin/bash

# Download Objective Sharpie first:
# https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/objective_sharpie/

SDK=$(sharpie xcode -sdks | awk '/sdk: iphoneos.*/{print $2}' | head -n 1)
if [ -z "$SDK" ]; then
    echo "No SDK found"
    exit 1
fi

echo "SDK used: ${SDK}"
sharpie bind --output=./ --namespace=YandexMetrica --sdk="${SDK}" Headers/*.h
