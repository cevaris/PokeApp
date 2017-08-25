#!/usr/bin/env bash

set -x

DATA_DIR=/git/pokedex/pokedex/data/csv
DEST_DIR=/git/PokeApp/PokeApp/Resources/
ZIP_NAME=pokedex.zip

# execute script in tmp
cd /tmp

# zip csv files
zip -r -X $ZIP_NAME $DATA_DIR

mv $ZIP_NAME $DEST_DIR
