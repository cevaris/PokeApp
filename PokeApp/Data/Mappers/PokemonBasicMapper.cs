using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeApp.Data.Models;
using PokeApp.Data.Tables;
using PokeApp.Utils;

namespace PokeApp.Data.Mappers
{
    public class PokemonBasicMapper : Mapper
    {
        private static int PageSize = 5;
        private static readonly ILogger Logger = new ConsoleLogger(nameof(PokemonBasicMapper));

        public static async Task<List<PokemonBasicModel>> Page(int idOffset)
        {
            SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            List<PokemonBasicModel> results = new List<PokemonBasicModel>();

            LanguageTable langTable = Mapper.LanguageEnglish();

            Task<List<PokemonSpeciesTable>> speciesTask = conn.Table<PokemonSpeciesTable>()
                                                              .Skip(idOffset)
                                                              .Take(PageSize)
                                                              .ToListAsync();
            
            List<PokemonSpeciesTable> species = await speciesTask;
            List<int> speciesIds = species.Select(y => y.Id).ToList();

            Task<List<PokemonSpeciesNameTable>> namesTask = conn.Table<PokemonSpeciesNameTable>()
                                                                .Where(x => speciesIds.Contains(x.Id) && x.LanguageId == langTable.Id)
                                                                .ToListAsync();
            List<PokemonSpeciesNameTable> names = await namesTask;

            foreach (PokemonSpeciesTable pst in species)
            {
                string name = names.Find(x => x.Id == pst.Id).Name;
                PokemonBasicModel instance = new PokemonBasicModel()
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
