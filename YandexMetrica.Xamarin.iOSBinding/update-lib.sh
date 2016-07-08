#!/bin/bash

pod repo update

METRICA_OLD_VER=$(ls | grep libYandexMobileMetrica-*.a | sed -e "s/libYandexMobileMetrica-\(.*\).a/\1/")
METRICA_SPEC=$(pod spec cat YandexMobileMetrica)
METRICA_NEW_VER=$(echo "$METRICA_SPEC" | grep s.version | sed -e "s,.*'\(.*\)'.*,\1,")

if [[ "$METRICA_OLD_VER" == "$METRICA_NEW_VER" ]]; then
    echo "AppMetrica is up to date (v$METRICA_OLD_VER)"
    exit 0
fi

TMPDIR=update_tmp
METRICA_OLD_FILENAME=libYandexMobileMetrica-"$METRICA_OLD_VER"
METRICA_NEW_FILENAME=libYandexMobileMetrica-"$METRICA_NEW_VER"
METRICA_PROJ_FILE=YandexMetrica.Xamarin.iOSBinding.csproj

echo "Creating temp directory '$TMPDIR'"
rm -rf "$TMPDIR" && mkdir "$TMPDIR"
cd "$TMPDIR"

echo "Downloading YandexMobileMetrica framework"
SDK_ZIP_URL=$(echo "$METRICA_SPEC" | grep s.source | sed -e "s,.*\(https://.*zip\).*,\1,")
echo "URL: $SDK_ZIP_URL"
wget -q -O framework.zip -- "$SDK_ZIP_URL"
unzip -q framework.zip

echo "Copying library and headers from framework"
cp YandexMobileMetrica.framework/YandexMobileMetrica ../libYandexMobileMetrica-"$METRICA_NEW_VER".a
rm ../libYandexMobileMetrica-"$METRICA_OLD_VER".a
mv ../libYandexMobileMetrica-"$METRICA_OLD_VER".linkwith.cs ../libYandexMobileMetrica-"$METRICA_NEW_VER".linkwith.cs
rm -rf ../Headers
cp -r YandexMobileMetrica.framework/Headers ../Headers

cd ..

echo "Updating project"
replace_filename () {
    sed -i -e "s,\(.*\)$METRICA_OLD_FILENAME\(.*\),\1$METRICA_NEW_FILENAME\2,g" "$0"
    rm "$0"-e
    perl -i -pe "chomp if eof" "$0"
}
replace_filename "$METRICA_PROJ_FILE"
replace_filename libYandexMobileMetrica-"$METRICA_NEW_VER".linkwith.cs

echo "Generating bindings"
./generate-binding.sh

rm -rf "$TMPDIR"
