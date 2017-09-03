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

            Task<GenerationTable> taskGeneration = conn.Table<GenerationTable>()
                                                        .Where(x => x.Id == speciesTable.GenerationId && x.LanguageId == langTable.Id)
                                                        .FirstAsync();

            Task<HabitatTable> taskHabbit = conn.Table<HabitatTable>()
                                                .Where(x => x.Id == speciesTable.HabitatId && x.LanguageId == langTable.Id)
                                                .FirstAsync();

            await Task.WhenAll(
                taskGeneration,
                taskHabbit
            );
            HabitatTable habbit = await taskHabbit;
            GenerationTable generation = await taskGeneration;

            return new PokemonModel()
            {
                Id = speciesTable.Id,
                Name = pokemonName.Name,
                Weight = pokemonTable.Weight,
                HabitatName = App.Shared.ToTitleCase(habbit.Name),
                Height = pokemonTable.Height,
                Genus = pokemonName.Genus,
                GenerationName = generation.Name,
                BaseExperience = pokemonTable.BaseExperience,
                SpeciesId = speciesTable.Id,
                SpriteUrl = PokeUtils.GetImage(speciesTable.Id)
            };
        }
    }
}
