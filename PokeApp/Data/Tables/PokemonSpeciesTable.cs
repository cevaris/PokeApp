using System;
using PokeApp.Utils;
using SQLite;

namespace PokeApp.Data
{
    public class PokemonSpeciesTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int GenerationId { get; set; }

        public int? EvolutionChainId { get; set; }

        public int? EvolvesFromSpeciesId { get; set; }

        public int? HabitatId { get; set; }

        public int CaptureRate { get; set; }


        public static PokedexTable FromCsv(string line)
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
    }
}
