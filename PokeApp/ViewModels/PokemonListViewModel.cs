using PokeApp.Data;
using PokeApp.Models;
using System.Collections.ObjectModel;

namespace PokeApp
{
    public class PokemonListViewModel
    {
        public ObservableCollection<PokemonModel> PokemonList { get; set; }

        public PokemonListViewModel()
        {
            // replace with http query
            PokemonList = new ObservableCollection<PokemonModel>();
            foreach(PokemonModel p in Constants.TestPokemonModels){
                PokemonList.Add(p);
            }
        }
    }
}
