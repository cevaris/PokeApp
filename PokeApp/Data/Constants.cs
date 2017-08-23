using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PokeApp.Models;

namespace PokeApp.Data
{
    public class Constants
    {

        public const string DatabaseName = "PokeApp.db3";
        public static readonly List<PokemonModel> TestPokemonModels = new List<PokemonModel>()
        {
            new PokemonModel()
            {
                Id=4,
                Name="charmander",
                QueriedAt = System.DateTime.UtcNow,
                SpriteFront = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png",
                SpriteBack = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/4.png",
                Url = "https://pokeapi.co/api/v2/pokemon/4/"
            },
            new PokemonModel()
            {
                Id=5,
                Name="charmelean",
                QueriedAt = System.DateTime.UtcNow.AddDays(-2),
                SpriteFront = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png",
                SpriteBack = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/5.png",
                Url = "https://pokeapi.co/api/v2/pokemon/5/"
            }
        };

        public const string TestPokemonIndexesModelJson0 = @"{""count"":811,""previous"":null,""results"":[{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/1\/"",""name"":""bulbasaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/2\/"",""name"":""ivysaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/3\/"",""name"":""venusaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/4\/"",""name"":""charmander""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/5\/"",""name"":""charmeleon""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/6\/"",""name"":""charizard""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/7\/"",""name"":""squirtle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/8\/"",""name"":""wartortle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/9\/"",""name"":""blastoise""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/10\/"",""name"":""caterpie""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/11\/"",""name"":""metapod""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/12\/"",""name"":""butterfree""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/13\/"",""name"":""weedle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/14\/"",""name"":""kakuna""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/15\/"",""name"":""beedrill""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/16\/"",""name"":""pidgey""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/17\/"",""name"":""pidgeotto""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/18\/"",""name"":""pidgeot""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/19\/"",""name"":""rattata""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/20\/"",""name"":""raticate""}],""next"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/?offset=20""}";
        public const string TestPokemonIndexesModelJson1 = @"{""count"":811,""previous"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/"",""results"":[{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/21\/"",""name"":""spearow""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/22\/"",""name"":""fearow""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/23\/"",""name"":""ekans""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/24\/"",""name"":""arbok""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/25\/"",""name"":""pikachu""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/26\/"",""name"":""raichu""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/27\/"",""name"":""sandshrew""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/28\/"",""name"":""sandslash""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/29\/"",""name"":""nidoran-f""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/30\/"",""name"":""nidorina""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/31\/"",""name"":""nidoqueen""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/32\/"",""name"":""nidoran-m""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/33\/"",""name"":""nidorino""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/34\/"",""name"":""nidoking""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/35\/"",""name"":""clefairy""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/36\/"",""name"":""clefable""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/37\/"",""name"":""vulpix""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/38\/"",""name"":""ninetales""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/39\/"",""name"":""jigglypuff""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/40\/"",""name"":""wigglytuff""}],""next"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/?offset=40""}";

        public static readonly PokemonIndexesModel TestPokemonIndexesModel0 =
            JsonConvert.DeserializeObject<PokemonIndexesModel>(TestPokemonIndexesModelJson0);

        public static readonly PokemonIndexesModel TestPokemonIndexesModel1 =
            JsonConvert.DeserializeObject<PokemonIndexesModel>(TestPokemonIndexesModelJson1);

        public static readonly List<PokemonIndexesModel> TestPokemonIndexModels = new List<PokemonIndexesModel>(){
            TestPokemonIndexesModel0,
            TestPokemonIndexesModel1
        };

        public static readonly List<ResourceModel> TestResourceModelList = new List<ResourceModel>()
        {
            new ResourceModel()
            {
                Url = "https://pokeapi.co/api/v2/pokemon/",
                Body = TestPokemonIndexesModelJson0,
                CreatedAt = DateTime.UtcNow
            },
            new ResourceModel()
            {
                Url = "https://pokeapi.co/api/v2/pokemon/?offset=20",
                Body = TestPokemonIndexesModelJson1,
                CreatedAt = DateTime.UtcNow
            }
        };
    }
}
