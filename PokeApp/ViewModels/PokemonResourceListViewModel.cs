using PokeApp.Data;
using PokeApp.Data.Tables;
using System.Collections.ObjectModel;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        public ObservableCollection<PokemonSpeciesTable> List { get; set; }

        public PokemonResourceListViewModel()
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            var query = conn.Table<PokemonSpeciesTable>().ToListAsync();

            List = new ObservableCollection<PokemonSpeciesTable>();
            foreach (PokemonSpeciesTable ps in query.Result)
            {
                List.Add(ps);
            }
        }
    }
}
