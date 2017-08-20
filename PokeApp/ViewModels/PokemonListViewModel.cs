using System.Collections.ObjectModel;

namespace PokeApp
{
    public class PokemonListViewModel
    {
        public ObservableCollection<PokemonModel> PokemonList { get; set; }

        public PokemonListViewModel()
        {
            // replace with http query
            PokemonList = new ObservableCollection<PokemonModel>()
            {
                new PokemonModel {Name="charmander", Id=4},
                new PokemonModel {Name="charmelean", Id=5}
            };
        }
    }
}
