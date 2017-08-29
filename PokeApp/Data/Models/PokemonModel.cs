using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeApp.Data.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }

        public string Name { get; set; }
        public string GenerationName { get; set; }
        public string HabitatName { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }

        public string SpriteUrl { get; set; }

        public string DisplayId
        {
            get
            {
                return $"#{Id}";
            }
        }
    }
}
