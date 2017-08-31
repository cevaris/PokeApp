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

        public ObservableCollection<PokemonSpeciesTable> PokemonList { get; set; }

        public PokemonResourceListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonSpeciesTable>();

            MessagingCenter.Subscribe<PokedexStorage>(this, "PokedexStorage.Update", (sender) =>
            {
                Update();
            });
            MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonResourceListViewModel.Page", (sender, e) =>
            {
                Logger.Info($"item visible: {e} {e.Item.ToString()} {PokemonList[PokemonList.Count - 1]}");
                Update(((PokemonSpeciesTable)e.Item).Id);
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

        public async void Update(int id)
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            var query = conn.Table<PokemonSpeciesTable>().Where(x => x.Id == id).FirstAsync();

            PokemonSpeciesTable data = await query;
            PokemonList.Add(data);
        }

        public async void Update()
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            var query = conn.Table<PokemonSpeciesTable>().Take(20).ToListAsync();

            List<PokemonSpeciesTable> data = await query;
            foreach (PokemonSpeciesTable pst in data)
            {
                PokemonList.Add(pst);
            }

            foreach (int i in Enumerable.Range(21, 802))
            {
                PokemonList.Add(new PokemonSpeciesTable()
                {
                    Id = i
                });
            }
        }
    }
}
