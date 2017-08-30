using PokeApp.Data.Tables;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        public ObservableCollection<PokemonSpeciesTable> PokemonList =
            new ObservableCollection<PokemonSpeciesTable>();
        
        public static PokemonResourceListViewModel Preview = PreviewInit();
        public static PokemonResourceListViewModel PreviewInit()
        {
            var preview = new PokemonResourceListViewModel();
            preview.PokemonList.Add(new PokemonSpeciesTable()
            {
                Id = 1,
                Identifier = "Bulbasaur"
            });
            preview.PokemonList.Add(new PokemonSpeciesTable()
            {
                Id = 2,
                Identifier = "Ivysaur"
            });
            return preview;
        }

        public async void Update()
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            var query = conn.Table<PokemonSpeciesTable>().ToListAsync();

            List<PokemonSpeciesTable> data = await query;

            PokemonList.Clear();
            foreach (PokemonSpeciesTable pst in data)
            {
                PokemonList.Add(pst);
            }
        }
    }
}
