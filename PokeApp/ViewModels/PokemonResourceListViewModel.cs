using PokeApp.Data;
using PokeApp.Models;
using System.Collections.ObjectModel;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        public ObservableCollection<NamedApiResource> List { get; set; }

        public PokemonResourceListViewModel()
        {
            List = new ObservableCollection<NamedApiResource>();
            foreach (PokemonResourceList ps in Constants.TestPokemonIndexModels)
            {
                foreach (NamedApiResource p in ps.Results)
                {
                    List.Add(p);
                }
            }
        }
    }
}
