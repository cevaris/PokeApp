using System;
using SQLite;

namespace PokeApp.Data
{

    public class PokemonSpeciesTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int GenerationId { get; set; }

        public Nullable<int> EvolutionChainId { get; set; }

        public Nullable<int> EvolvesFromSpeciesId { get; set; }

        public Nullable<int> HabitatId { get; set; }

        public int CaptureRate { get; set; }

        [Ignore]
        public string FrontSpriteUrl
        {
            get
            {
                return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
            }
        }

    }
}
