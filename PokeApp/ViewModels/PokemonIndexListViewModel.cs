using PokeApp.Data;
using PokeApp.Models;
using System.Collections.ObjectModel;

namespace PokeApp
{
    public class PokemonIndexListViewModel
    {
        public ObservableCollection<PokemonIndexModel> PokemonIndexList { get; set; }

        public PokemonIndexListViewModel()
        {
            PokemonIndexList = new ObservableCollection<PokemonIndexModel>();
            foreach (PokemonIndexesModel ps in Constants.TestPokemonIndexModels)
            {
                foreach (PokemonIndexModel p in ps.Results)
                {
                    PokemonIndexList.Add(p);
                }
            }
        }
    }
}
