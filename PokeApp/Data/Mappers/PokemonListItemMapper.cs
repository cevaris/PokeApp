using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApp.Data.Models;
using PokeApp.Data.Tables;
using PokeApp.Utils;

namespace PokeApp.Data.Mappers
{
    public class PokemonListItemMapper : Mapper
    {
        private static readonly ILogger Logger = new ConsoleLogger(nameof(PokemonListItemMapper));

        public static async Task<List<PokemonListItemModel>> Page(int idOffset, string nameQuery, int pageSize)
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            List<PokemonListItemModel> results = new List<PokemonListItemModel>();

            LanguageTable langTable = Mapper.LanguageEnglish();

            Task<List<PokemonSpeciesTable>> speciesTask;
            if (nameQuery == null)
            {
                speciesTask = conn.Table<PokemonSpeciesTable>()
                                  .Skip(idOffset)
                                  .Take(pageSize)
                                  .ToListAsync();
            }
            else
            {
                speciesTask = conn.Table<PokemonSpeciesTable>()
                                  .Where(x => x.Identifier.Contains(nameQuery))
                                  .Skip(idOffset)
                                  .Take(pageSize)
                                  .ToListAsync();
            }

            List<PokemonSpeciesTable> species = await speciesTask;
            List<int> speciesIds = species.Select(y => y.Id).ToList();

            Task<List<PokemonSpeciesNameTable>> namesTask = conn.Table<PokemonSpeciesNameTable>()
                                                                .Where(x => speciesIds.Contains(x.Id) && x.LanguageId == langTable.Id)
                                                                .ToListAsync();
            List<PokemonSpeciesNameTable> names = await namesTask;

            foreach (PokemonSpeciesTable pst in species)
            {
                string name = names.Find(x => x.Id == pst.Id).Name;
                PokemonListItemModel instance = new PokemonListItemModel()
                {
                    Id = pst.Id,
                    Name = name,
                    SpriteUrl = PokeUtils.GetImage(pst.Id)
                };
                results.Add(instance);
            }

            return results;
        }

    }
}
