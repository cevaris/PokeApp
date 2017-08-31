using System;
using System.Threading.Tasks;
using PokeApp.Data.Models;
using PokeApp.Data.Tables;
using System.Linq;
using System.Collections.Generic;

namespace PokeApp.Data.Mappers
{
    public class PokemonMapper : Mapper
    {
        public static async Task<PokemonModel> GetById(int id)
        {
            var conn = App.Shared.GetAsyncConnection();

            LanguageTable langTable = await Mapper.LanguageEnglish();

            Task<PokemonSpeciesTable> taskSpeciesTable = conn.Table<PokemonSpeciesTable>()
                                                        .Where(x => x.Id == id)
                                                        .FirstAsync();

            Task<PokemonTable> taskPokemonTable = conn.Table<PokemonTable>()
                                                        .Where(x => x.Id == id)
                                                        .FirstAsync();

            Task<PokemonSpeciesNameTable> taskPokemonName = conn.Table<PokemonSpeciesNameTable>()
                                                                 .Where(x => x.Id == id && x.LanguageId == langTable.Id)
                                                                 .FirstAsync();

            await Task.WhenAll(
                taskSpeciesTable,
                taskPokemonTable,
                taskPokemonName
            );

            PokemonSpeciesTable speciesTable = await taskSpeciesTable;
            PokemonTable pokemonTable = await taskPokemonTable;
            PokemonSpeciesNameTable pokemonName = await taskPokemonName;

            return new PokemonModel()
            {
                Id = speciesTable.Id,
                Name = pokemonName.Name,
                Weight = pokemonTable.Weight,
                Height = pokemonTable.Height,
                BaseExperience = pokemonTable.BaseExperience,
                SpeciesId = speciesTable.Id,
                SpriteUrl = $"https://s3-us-west-2.amazonaws.com/assets.images.pokemon/{speciesTable.Id}.png"
            };
        }
    }
}
