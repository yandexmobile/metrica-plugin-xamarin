#!/bin/bash

set -e

METRICA_PROJ_FILE=YandexMetrica.Xamarin.iOSBinding.csproj

pod repo update master

METRICA_OLD_VER=$(sed -n -e "s,.*<NativeAppMetricaSdkVersion>\(.*\)</NativeAppMetricaSdkVersion>.*,\1,p" "$METRICA_PROJ_FILE")
METRICA_SPEC=$(pod spec cat YandexMobileMetrica)
METRICA_NEW_VER=$(echo "$METRICA_SPEC" | python -c 'import json,sys;print(json.load(sys.stdin)["version"])')

if [[ "$METRICA_OLD_VER" == "$METRICA_NEW_VER" ]]; then
    echo "AppMetrica is up to date (v$METRICA_OLD_VER)"
    exit 0
fi

TMPDIR=update_tmp
METRICA_OLD_FILENAME=libYandexMobileMetrica-"$METRICA_OLD_VER"
METRICA_NEW_FILENAME=libYandexMobileMetrica-"$METRICA_NEW_VER"

echo "Creating temp directory '$TMPDIR'"
rm -rf "$TMPDIR" && mkdir "$TMPDIR"
cd "$TMPDIR"

echo "Downloading YandexMobileMetrica framework"
SDK_ZIP_URL=$(echo "$METRICA_SPEC" | python -c 'import json,sys;print(json.load(sys.stdin)["source"]["http"])')
echo "URL: $SDK_ZIP_URL"
wget -q -O framework.zip -- "$SDK_ZIP_URL"
unzip -q framework.zip

echo "Copying library and headers from framework"
copy_library_and_headers_from_framework() { #1 - framework name
	cp "static/$1.framework/$1" "../Libs/lib$1-${METRICA_NEW_VER}.a"
	cp -r "static/$1.framework/Headers" "../Headers/$1"
}
rm -rf ../Headers && mkdir ../Headers
rm -rf ../Libs && mkdir ../Libs
copy_library_and_headers_from_framework YandexMobileMetrica
copy_library_and_headers_from_framework YandexMobileMetricaCrashes

cd ..

echo "Updating project"
sed -i -e "s,\(<NativeAppMetricaSdkVersion>\)$METRICA_OLD_VER\(</NativeAppMetricaSdkVersion>\),\1$METRICA_NEW_VER\2,g" "$METRICA_PROJ_FILE"
rm "$METRICA_PROJ_FILE-e"
perl -i -pe "chomp if eof" "$METRICA_PROJ_FILE"

echo "Generating bindings"
./generate-binding.sh

rm -rf "$TMPDIR"
