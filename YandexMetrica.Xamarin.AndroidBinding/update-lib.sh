#!/bin/bash

METRICA_OLD_VER=$(ls Jars/ | grep mobmetricalib | sed -n "s/mobmetricalib-\(.*\).aar/\1/p")
METRICA_NEW_VER=$(curl https://oss.sonatype.org/content/groups/public/com/yandex/android/mobmetricalib/maven-metadata.xml 2>/dev/null | grep latest | sed -n 's/ *<latest>\(.*\)<.latest>/\1/p')

if [[ "$METRICA_OLD_VER" == "$METRICA_NEW_VER" ]]; then
    echo "AppMetrica is up to date (v$METRICA_OLD_VER)"
    exit 0
fi

METRICA_JARS_DIR=Jars
METRICA_OLD_FILENAME=mobmetricalib-"$METRICA_OLD_VER".aar
METRICA_NEW_FILENAME=mobmetricalib-"$METRICA_NEW_VER".aar
METRICA_DOWNLOAD_URL=https://oss.sonatype.org/content/groups/public/com/yandex/android/mobmetricalib/"$METRICA_NEW_VER"/mobmetricalib-"$METRICA_NEW_VER".aar
METRICA_PROJ_FILE=YandexMetrica.Xamarin.AndroidBinding.csproj

echo "Downloading AppMetrica v$METRICA_NEW_VER"
wget -O "$METRICA_JARS_DIR/$METRICA_NEW_FILENAME" -- "$METRICA_DOWNLOAD_URL" 2>/dev/null

echo "Removing old AppMetrica: $METRICA_OLD_FILENAME"
rm "$METRICA_JARS_DIR/$METRICA_OLD_FILENAME"

echo "Updating project"
sed -i -e "s,\(.*\)$METRICA_OLD_FILENAME\(.*\),\1$METRICA_NEW_FILENAME\2,g" "$METRICA_PROJ_FILE"
rm "$METRICA_PROJ_FILE"-e
perl -i -pe "chomp if eof" "$METRICA_PROJ_FILE"
