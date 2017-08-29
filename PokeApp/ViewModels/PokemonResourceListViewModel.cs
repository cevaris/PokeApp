using PokeApp.Data;
using PokeApp.Data.Tables;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PokeApp
{
    public class PokemonResourceListViewModel
    {
        public ObservableCollection<PokemonSpeciesTable> PokemonList { get; set; }

        public PokemonResourceListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonSpeciesTable>();
            PokemonList.Add(
                new PokemonSpeciesTable()
                {
                    Id = 1,
                    Identifier = "bulbasaur"
                }
            );
            PokemonList.Add(
                new PokemonSpeciesTable()
                {
                    Id = 2,
                    Identifier = "Ivysaur"
                }
            );
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
