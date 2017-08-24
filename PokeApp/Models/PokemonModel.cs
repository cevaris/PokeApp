using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeApp.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Id { get; set; }

        public PokemonSprite Sprites { get; set; }

        public List<PokemonTypeResource> Types { get; set; }
        public List<PokemonStatResource> Stats { get; set; }

        public string IdDisplay
        {
            get
            {
                return $"#{Id}";
            }
        }
    }

    public class PokemonSprite
    {
        [JsonProperty(PropertyName = "front_default")]
        public string FrontDefault { get; set; }
        [JsonProperty(PropertyName = "back_default")]
        public string BackDefault { get; set; }
    }

    public class PokemonTypeResource
    {
        public int Slot { get; set; }
        public NamedApiResource Type { get; set; }
    }

    public class PokemonStatResource
    {
        public int BaseStat { get; set; }
        public NamedApiResource Stat { get; set; }
    }
}
