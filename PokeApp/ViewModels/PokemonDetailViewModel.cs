using PokeApp.Data;
using PokeApp.Models;

namespace PokeApp
{
    public class PokemonDetailViewModel
    {
        public PokemonModel Pokemon { get; set; }

        public PokemonDetailViewModel()
        {
            Pokemon = Constants.TestPokemonModels[0];
        }

        public PokemonDetailViewModel(PokemonModel pokemon)
        {
            Pokemon = pokemon;
        }

    }
}
