#!/usr/bin/env python

import os
import sys
import hashlib
from os.path import expanduser


def main(image_dir):
    salt = os.environ.get('SALTY')
    if salt == None:
        raise ValueError('missing salt env var')

    files = os.walk(image_dir)
    for i in xrange(1, 803):
        hasher = hashlib.md5()
        hasher.update('{}-{}'.format(i,salt))
        new_file_name = os.path.join(image_dir, hasher.hexdigest() + '.jpg')
        old_file_name = os.path.join(image_dir, str(i) + '.jpg')
        if os.path.exists(old_file_name):
            os.rename(old_file_name, new_file_name)
            print('renaming {} to {}'.format(old_file_name, new_file_name))
    print('done renaming files')


if __name__ == "__main__":
    if len(sys.argv) != 2:
        print('usage: {} path/to/image/dir'.format(os.path.realpath(__file__)))
        raise ValueError('invalid arguments')

    main(sys.argv[1])
