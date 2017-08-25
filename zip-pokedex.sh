#!/usr/bin/env bash

set -x

DATA_DIR=/git/pokedex/pokedex/data/csv
DEST_IOS_DIR=/git/PokeApp/iOS/Resources
ZIP_NAME=Pokedex.zip

# execute script in tmp
cd $DATA_DIR

# zip csv files
zip -r -X $ZIP_NAME .

cp $ZIP_NAME $DEST_IOS_DIR

rm $ZIP_NAME
