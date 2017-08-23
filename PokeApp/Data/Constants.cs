using System;
using System.Collections.Generic;
using PokeApp.Models;

namespace PokeApp.Data
{
    public class Constants
    {
        public static readonly string DatabaseName = "PokeApp.db3";
        public static readonly List<PokemonModel> TestPokemonModels = new List<PokemonModel>(){
            new PokemonModel {
                Id=4,
                Name="charmander",
                QueriedAt = System.DateTime.UtcNow,
                SpriteFront = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png",
                SpriteBack = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/4.png",
                Url = "https://pokeapi.co/api/v2/pokemon/4/"
            },
            new PokemonModel {
                Id=5,
                Name="charmelean",
                QueriedAt = System.DateTime.UtcNow.AddDays(-2),
                SpriteFront = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png",
                SpriteBack = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/5.png",
                Url = "https://pokeapi.co/api/v2/pokemon/5/"
            }
        };
    }
}
