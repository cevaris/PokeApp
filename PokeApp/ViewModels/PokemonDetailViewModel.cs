namespace PokeApp
{
    public class PokemonDetailViewModel
    {
        public PokemonModel Pokemon { get; set; }

        public PokemonDetailViewModel()
        {
            Pokemon = new PokemonModel()
            {
                Name = "Pokemon Name",
                Id = 3
            };
        }

        public PokemonDetailViewModel(PokemonModel pokemon)
        {
            Pokemon = pokemon;
        }

    }
}
