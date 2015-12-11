#!/bin/bash

cd Updater

echo "Updating Pods"
pod update

echo "Building symbols for device architectures"
./gradlew buildForDevice

echo "Building symbols for simulator architectures"
./gradlew buildForSimulator

echo "Linking and updating libraries"
for libName in 'libFMDB' 'libKSCrash' 'libprotobuf-c'; do
    libtool -static -o ../"$libName".a build/sym/Release-iphonesimulator/"$libName".a build/sym/Release-iphoneos/"$libName".a
done
cp -f Pods/YandexMobileMetrica/libYandexMobileMetrica.a ../
