using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Utils;
using System.Linq;
using System.Threading.Tasks;
using PokeApp.Data.Mappers;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonResourceListViewModel));

        public bool IsLoading { get; set; }

        public ObservableCollection<PokemonSpeciesTable> PokemonList { get; set; }

        public PokemonResourceListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonSpeciesTable>();
            IsLoading = true;

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

        public async void Update(int idOffset)
        {
            IsLoading = true;
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            LanguageTable langTable = await Mapper.LanguageEnglish();

            Task<List<PokemonSpeciesTable>> speciesTask = conn.Table<PokemonSpeciesTable>()
                            .Skip(idOffset)
                            .Take(20).ToListAsync();

            List<PokemonSpeciesTable> species = await speciesTask;
            IEnumerable<int> speciesIds = species.Select(y => y.Id);

            Task<List<PokemonSpeciesNameTable>> namesTask = conn.Table<PokemonSpeciesNameTable>()
                                                                .Where(x => speciesIds.Contains(x.Id) && x.LanguageId == langTable.Id)
                                                                .ToListAsync();
            List<PokemonSpeciesNameTable> names = await namesTask;

            foreach (PokemonSpeciesTable pst in species)
            {
                pst.Identifier = names.Find(x => x.Id == pst.Id).Name;
                PokemonList.Add(pst);
            }
            IsLoading = false;
        }
    }
}
