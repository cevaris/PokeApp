using System;

namespace PokeApp.Data.Tables
{

    public class PokemonSpeciesTable : PokedexTable
    {
        [SQLite.PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int GenerationId { get; set; }

        public Nullable<int> EvolutionChainId { get; set; }

        public Nullable<int> EvolvesFromSpeciesId { get; set; }

        public Nullable<int> HabitatId { get; set; }

        public int CaptureRate { get; set; }

        [SQLite.Ignore]
        public string FrontSpriteUrl
        {
            get
            {

                return $"https://s3-us-west-2.amazonaws.com/assets.images.pokemon/{Id}.png";
                //string prefix = null;
                //switch (GenerationId)
                //{
                //    case 1:
                //    case 2:
                //    case 3:
                //    case 4:                       
                //    case 5:                      
                //    case 6:
                //        prefix = "omega-ruby-alpha-sapphire";
                //        break;
                //    case 7:
                //        prefix = "sun-moon";
                //        break;
                //    default:
                //        throw new Exception($"invalid generation id found {GenerationId}");
                //}
                // return $"https://img.pokemondb.net/sprites/{prefix}/dex/normal/{Identifier}.png";

                // BEST
                //return $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{Id.ToString("000")}.png";

                //https://img.pokemondb.net/sprites/omega-ruby-alpha-sapphire/dex/normal/fennekin.png
                //return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
                //return $"https://img.pokemondb.net/artwork/{Identifier}.jpg"; 
                //return $"http://www.psypokes.com/dex/regular/{Id.ToString("000")}.png";




            }
        }

    }
}
