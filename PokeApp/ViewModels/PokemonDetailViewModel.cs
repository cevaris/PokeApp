using PokeApp.Data;
using PokeApp.Data.Models;

namespace PokeApp
{
    public class PokemonDetailViewModel
    {
        public static PokemonDetailViewModel Preview = new PokemonDetailViewModel()
        {
            Pokemon = Constants.TestPokemonModel1
        };

        public PokemonModel Pokemon { get; set; }
    }
}
