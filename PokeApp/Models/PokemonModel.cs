using System;

namespace PokeApp.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }

        public int Id { get; set; }
        
        public string IdDisplay
        {
            get
            {
                return $"#{Id}";
            }
        }

        public string Url { get; set; }

        public DateTime QueriedAt { get; set; }
        public string QueriedAtDisplay
        {
            get
            {
                return $"QuriedAt: {QueriedAt}";
            }
        }

        public string SpriteFront { get; set; }
        public string SpriteBack { get; set; }
    }
}
