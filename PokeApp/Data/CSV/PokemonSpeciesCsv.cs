using PokeApp.Utils;
using System;

namespace PokeApp.Data.Csv
{

    public class PokemonSpeciesCsv : ICsvInfo
    {
        public PokedexTable FromCsv(string line)
        {
            String[] data = line.Split(',');

            var instance = new PokemonSpeciesTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                Identifier = data[1],
                GenerationId = TextUtils.ParseInt32(data[2]),
                EvolvesFromSpeciesId = TextUtils.ParseNInt32(data[3]),
                EvolutionChainId = TextUtils.ParseNInt32(data[4]),
                HabitatId = TextUtils.ParseNInt32(data[7]),
                CaptureRate = TextUtils.ParseInt32(data[9])
            };

            return instance;
        }

        public string Filename()
        {
            return "pokemon_species.csv";
        }
    }
}
