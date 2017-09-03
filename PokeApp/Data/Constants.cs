using System.Collections.Generic;
using PokeApp.Data.Models;

namespace PokeApp.Data
{
    public class Constants
    {
        public const string Locale = "en";
        public const string DatabaseName = "PokeApp.db3";
        public const string ZipName = "Pokedex.zip";

        public static readonly PokemonModel TestPokemonModel1 = new PokemonModel()
        {
            Id = 1,
            Name = "Bulbasaur",
            SpriteUrl = PokeUtils.GetImage(1),
            Weight = 22,
            Height = 33,
            BaseExperience = 44
        };
        public static readonly PokemonModel TestPokemonModel2 = new PokemonModel()
        {
            Id = 2,
            Name = "Ivysaur",
            SpriteUrl = PokeUtils.GetImage(2),
            Weight = 111,
            Height = 222,
            BaseExperience = 333
        };
        public static readonly List<PokemonModel> TestPokemonModels = new List<PokemonModel>()
        {
            TestPokemonModel1,
            TestPokemonModel2
        };

    }
}
