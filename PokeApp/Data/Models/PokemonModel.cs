using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeApp.Data.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Generation { get; set; }
        public string Habitat { get; set; }
        public int SpriteUrl { get; set; }
        public string DisplayId
        {
            get
            {
                return $"#{Id}";
            }
        }
    }
}
