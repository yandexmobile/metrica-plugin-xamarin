#!/bin/bash

echo "Updating Android"
cd YandexMetrica.Xamarin.AndroidBinding
./update-lib.sh
cd ..

echo "Updating iOS"
cd YandexMetrica.Xamarin.iOSBinding
./update-lib.sh
cd ..
