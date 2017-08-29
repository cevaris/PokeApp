using PokeApp.Data;
using PokeApp.Data.Models;

namespace PokeApp
{
    public class PokemonDetailViewModel
    {
        public PokemonModel Pokemon { get; set; }

        public PokemonDetailViewModel()
        {
            Pokemon = Constants.TestPokemonModel1;
        }

        public PokemonDetailViewModel(PokemonModel pokemon)
        {
            Pokemon = pokemon;
        }

    }
}
