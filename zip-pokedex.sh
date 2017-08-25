#!/usr/bin/env bash

set -x

DATA_DIR=/git/pokedex/pokedex/data/csv
ZIP_NAME=Pokedex.zip

# execute script in tmp
cd $DATA_DIR

# zip csv files
zip -r -X $ZIP_NAME .


DEST_IOS_DIR=/git/PokeApp/iOS/Resources
cp $ZIP_NAME $DEST_IOS_DIR

DEST_ANDROID_DIR=/git/PokeApp/Droid/Assets
cp $ZIP_NAME $DEST_ANDROID_DIR

rm $ZIP_NAME
