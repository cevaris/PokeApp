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
                //return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
                //return $"https://img.pokemondb.net/artwork/{Identifier}.jpg"; 
                return $"http://www.psypokes.com/dex/regular/{Id.ToString("000")}.png";
            }
        }

    }
}
