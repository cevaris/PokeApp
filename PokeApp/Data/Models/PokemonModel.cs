﻿namespace PokeApp.Data.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }

        public string Name { get; set; }
        public string GenerationName { get; set; }
        public string Genus { get; set; }
        public string HabitatName { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }

        public string SpriteUrl { get; set; }

        public string DisplayHeader
        {
            get
            {
                return $"#{Id} {Name} - {Genus.Replace("Pokémon", "")}";
            }
        }

        public string DisplayHabitat
        {
            get
            {
                return $"{HabitatName} Habitat";
            }
        }

        public string DisplayExperience
        {
            get
            {
                return $"{BaseExperience} xp";
            }
        }

        public string DisplayWeight
        {
            get
            {
                float meterToFeet = 2.20462f;
                float lbs = Weight / 10f * meterToFeet;
                return string.Format("{0:0.0} lbs", lbs);
            }
        }

        public string DisplayHeight
        {
            get
            {
                float kgToLbs = 3.28084f;
                float feet = Height / 10.0f * kgToLbs;
                return string.Format("{0:0.0} ft", feet);                
            }
        }
    }
}
