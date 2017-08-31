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

        public PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>();
            IsLoading = true;

            MessagingCenter.Subscribe<PokedexStorage>(this, "PokedexStorage.Update", (sender) =>
            {
                Update(0);
            });
            MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonListViewModel.Page", (sender, e) =>
            {
                if ((PokemonBasicModel)e.Item == PokemonList.Last())
                {
                    Update(((PokemonBasicModel)e.Item).Id + 1);
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
                    SpriteUrl = "https://s3-us-west-2.amazonaws.com/assets.images.pokemon/1.png"
                },
                new PokemonBasicModel()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    SpriteUrl = "https://s3-us-west-2.amazonaws.com/assets.images.pokemon/2.png"
                }
            }

        };

        public async void Update(int idOffset)
        {
            IsLoading = true;
            List<PokemonBasicModel> pageResults = await PokemonBasicMapper.Page(idOffset);
            foreach (PokemonBasicModel p in pageResults)
            {
                PokemonList.Add(p);
            }
            IsLoading = false;
        }
    }
}
