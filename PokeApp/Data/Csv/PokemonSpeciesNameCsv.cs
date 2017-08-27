using System;
using PokeApp.Utils;

namespace PokeApp.Data.Csv
{
    public class PokemonSpeciesNameCsv : ICsvInfo<PokemonSpeciesNameTable>
    {
        public string Filename()
        {
            return "pokemon_species_names.csv";
        }

        public PokemonSpeciesNameTable FromCsv(string line)
        {
            String[] data = line.Split(',');

            var instance = new PokemonSpeciesNameTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                LanguageId = TextUtils.ParseInt32(data[1]),
                Name = data[2],
                Genus = data[3]
            };

            return instance;
        }
    }
}
