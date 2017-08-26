using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PokeApp.Models;

namespace PokeApp.Data
{
    public class Constants
    {

        public const string DatabaseName = "PokeApp.db3";
        public const string ZipName = "Pokedex.zip";

        public const string TestPokemonModelJson1 = @"{""id"": 1, ""name"": ""bulbasaur"", ""weight"": 69, ""stats"": [{""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/6\/"", ""name"": ""speed""}, ""effort"": 0, ""base_stat"": 45 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/5\/"", ""name"": ""special-defense""}, ""effort"": 0, ""base_stat"": 65 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/4\/"", ""name"": ""special-attack""}, ""effort"": 1, ""base_stat"": 65 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/3\/"", ""name"": ""defense""}, ""effort"": 0, ""base_stat"": 49 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/2\/"", ""name"": ""attack""}, ""effort"": 0, ""base_stat"": 49 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/1\/"", ""name"": ""hp""}, ""effort"": 0, ""base_stat"": 45 }], ""sprites"": {""back_female"": null, ""back_shiny_female"": null, ""back_default"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/back\/1.png"", ""front_female"": null, ""front_shiny_female"": null, ""back_shiny"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/back\/shiny\/1.png"", ""front_default"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/1.png"", ""front_shiny"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/shiny\/1.png""}, ""types"": [{""slot"": 2, ""type"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/type\/4\/"", ""name"": ""poison""} }, {""slot"": 1, ""type"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/type\/12\/"", ""name"": ""grass""} }] }";
        public const string TestPokemonModelJson2 = @"{""id"": 2, ""name"": ""ivysaur"", ""weight"": 130, ""stats"": [{""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/6\/"", ""name"": ""speed""}, ""effort"": 0, ""base_stat"": 60 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/5\/"", ""name"": ""special-defense""}, ""effort"": 1, ""base_stat"": 80 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/4\/"", ""name"": ""special-attack""}, ""effort"": 1, ""base_stat"": 80 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/3\/"", ""name"": ""defense""}, ""effort"": 0, ""base_stat"": 63 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/2\/"", ""name"": ""attack""}, ""effort"": 0, ""base_stat"": 62 }, {""stat"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/stat\/1\/"", ""name"": ""hp""}, ""effort"": 0, ""base_stat"": 60 }], ""types"": [{""slot"": 2, ""type"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/type\/4\/"", ""name"": ""poison""} }, {""slot"": 1, ""type"": {""url"": ""https:\/\/pokeapi.co\/api\/v2\/type\/12\/"", ""name"": ""grass""} }], ""sprites"": {""back_female"": null, ""back_shiny_female"": null, ""back_default"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/back\/2.png"", ""front_female"": null, ""front_shiny_female"": null, ""back_shiny"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/back\/shiny\/2.png"", ""front_default"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/2.png"", ""front_shiny"": ""https:\/\/raw.githubusercontent.com\/PokeAPI\/sprites\/master\/sprites\/pokemon\/shiny\/2.png""} }";

        public static readonly PokemonModel TestPokemonModel1 =
             JsonConvert.DeserializeObject<PokemonModel>(TestPokemonModelJson1);
        public static readonly PokemonModel TestPokemonModel2 =
            JsonConvert.DeserializeObject<PokemonModel>(TestPokemonModelJson2);
        public static readonly List<PokemonModel> TestPokemonModels = new List<PokemonModel>()
        {
            TestPokemonModel1,
            TestPokemonModel2
        };


        public const string TestPokemonIndexesModelJson0 = @"{""count"":811,""previous"":null,""results"":[{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/1\/"",""name"":""bulbasaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/2\/"",""name"":""ivysaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/3\/"",""name"":""venusaur""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/4\/"",""name"":""charmander""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/5\/"",""name"":""charmeleon""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/6\/"",""name"":""charizard""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/7\/"",""name"":""squirtle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/8\/"",""name"":""wartortle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/9\/"",""name"":""blastoise""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/10\/"",""name"":""caterpie""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/11\/"",""name"":""metapod""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/12\/"",""name"":""butterfree""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/13\/"",""name"":""weedle""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/14\/"",""name"":""kakuna""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/15\/"",""name"":""beedrill""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/16\/"",""name"":""pidgey""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/17\/"",""name"":""pidgeotto""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/18\/"",""name"":""pidgeot""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/19\/"",""name"":""rattata""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/20\/"",""name"":""raticate""}],""next"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/?offset=20""}";
        public const string TestPokemonIndexesModelJson1 = @"{""count"":811,""previous"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/"",""results"":[{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/21\/"",""name"":""spearow""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/22\/"",""name"":""fearow""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/23\/"",""name"":""ekans""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/24\/"",""name"":""arbok""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/25\/"",""name"":""pikachu""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/26\/"",""name"":""raichu""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/27\/"",""name"":""sandshrew""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/28\/"",""name"":""sandslash""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/29\/"",""name"":""nidoran-f""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/30\/"",""name"":""nidorina""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/31\/"",""name"":""nidoqueen""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/32\/"",""name"":""nidoran-m""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/33\/"",""name"":""nidorino""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/34\/"",""name"":""nidoking""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/35\/"",""name"":""clefairy""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/36\/"",""name"":""clefable""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/37\/"",""name"":""vulpix""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/38\/"",""name"":""ninetales""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/39\/"",""name"":""jigglypuff""},{""url"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/40\/"",""name"":""wigglytuff""}],""next"":""https:\/\/pokeapi.co\/api\/v2\/pokemon\/?offset=40""}";

        public static readonly PokemonResourceList TestPokemonIndexesModel0 =
            JsonConvert.DeserializeObject<PokemonResourceList>(TestPokemonIndexesModelJson0);
        public static readonly PokemonResourceList TestPokemonIndexesModel1 =
            JsonConvert.DeserializeObject<PokemonResourceList>(TestPokemonIndexesModelJson1);
        public static readonly List<PokemonResourceList> TestPokemonIndexModels = new List<PokemonResourceList>(){
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
