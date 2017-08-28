#!/usr/bin/env python
import requests
from os.path import expanduser


def main():

    home_dir = expanduser("~")

    for i in xrange(1, 803):
        url = 'https://assets.pokemon.com/assets/cms2/img/pokedex/full/{}.png'.format(str(i).zfill(3))
        print(url)

        response = requests.get(url)
        if response.status_code == 200:
            file_path = '{}/Desktop/assets/images/pokemon/{}.png'.format(home_dir, i)
            with open(file_path, 'wb') as f:
                f.write(response.content)
        else:
            raise AssertionError('failed downloading {}'.format(i))


if __name__ == "__main__":
    main()