using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Utils;
using System.Linq;
using System.Threading.Tasks;
using PokeApp.Data.Mappers;
using PokeApp.Data.Models;

namespace PokeApp
{
    public class PokemonListViewModel
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListViewModel));

        public bool IsLoading { get; set; }

        public ObservableCollection<PokemonBasicModel> PokemonList { get; set; }

        public string SearchQuery { get; set; }

        public PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>();
            IsLoading = true;

            MessagingCenter.Subscribe<PokedexStorage>(this, "PokedexStorage.Update", (sender) =>
            {
                SearchQuery = null;
                PokemonList.Clear();
                Update(0, SearchQuery);
            });

            MessagingCenter.Subscribe<PokemonListView, string>(this, "PokemonListViewModel.PageQuery", (sender, query) =>
            {
                if (query != null)
                    query = query.Trim().ToLower();
                
                Logger.Info($"received query: {query}");
                PokemonList.Clear();
                SearchQuery = query;
                Update(0, SearchQuery);
            });

            MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonListViewModel.Page", (sender, e) =>
            {
                if (PokemonList.Count > 0 && (PokemonBasicModel)e.Item == PokemonList.Last())
                {
                    Update(((PokemonBasicModel)e.Item).Id + 1, SearchQuery);
                }
            });
        }

        public static PokemonListViewModel Preview = new PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>(){
                new PokemonBasicModel()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    SpriteUrl = PokeUtils.GetImage(1)
                },
                new PokemonBasicModel()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    SpriteUrl = PokeUtils.GetImage(2)
                }
            }

        };

        public async void Update(int idOffset, string nameQuery)
        {
            IsLoading = true;
            List<PokemonBasicModel> pageResults = await PokemonBasicMapper.Page(idOffset, nameQuery);
            foreach (PokemonBasicModel p in pageResults)
            {
                PokemonList.Add(p);
            }
            IsLoading = false;
        }
    }
}
