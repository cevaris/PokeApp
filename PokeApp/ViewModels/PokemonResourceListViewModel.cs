using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Utils;
using System.Linq;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonResourceListViewModel));

        public bool IsLoading { get; set; }

        public ObservableCollection<PokemonSpeciesTable> PokemonList { get; set; }

        public int HighestIdLoaded { get; set; }

        public PokemonResourceListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonSpeciesTable>();
            IsLoading = true;
            HighestIdLoaded = 0;

            MessagingCenter.Subscribe<PokedexStorage>(this, "PokedexStorage.Update", (sender) =>
            {
                Update(0);
            });
            MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonResourceListViewModel.Page", (sender, e) =>
            {
                if ((PokemonSpeciesTable)e.Item == PokemonList.Last())
                {
                    Update(((PokemonSpeciesTable)e.Item).Id + 1);
                }
            });
        }

        public static PokemonResourceListViewModel Preview = new PokemonResourceListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonSpeciesTable>(){
                new PokemonSpeciesTable()
                {
                    Id = 1,
                    Identifier = "Bulbasaur"
                },
                new PokemonSpeciesTable()
                {
                    Id = 2,
                    Identifier = "Ivysaur"
                }
            }

        };

        //public async void Update(int id)
        //{


        //    IsLoading = true;
        //    SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
        //    var query = conn.Table<PokemonSpeciesTable>().Where(x => x.Id == id).FirstAsync();

        //    PokemonSpeciesTable data = await query;
        //    PokemonList.Add(data);
        //    IsLoading = false;
        //}

        public async void Update(int idOffset)
        {
            Logger.Info($"updating at offset {idOffset}");
            if (idOffset < HighestIdLoaded)
            {
                Logger.Info($"skipping loading of {idOffset}");
                return;
            }

            Logger.Info($"going to load {idOffset}");

            IsLoading = true;
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            var query = conn.Table<PokemonSpeciesTable>()
                            .Skip(idOffset)
                            .Take(20).ToListAsync();

            List<PokemonSpeciesTable> data = await query;
            foreach (PokemonSpeciesTable pst in data)
            {
                PokemonList.Add(pst);
                HighestIdLoaded = System.Math.Max(pst.Id, HighestIdLoaded);
            }
            IsLoading = false;
        }
    }
}
