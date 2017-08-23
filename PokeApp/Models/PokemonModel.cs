using System;
using SQLite;

namespace PokeApp.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }

        [PrimaryKey]
        public int Id { get; set; }
        [Ignore]
        public string IdDisplay
        {
            get
            {
                return $"#{Id}";
            }
        }

        [Indexed]
        public string Url { get; set; }

        public DateTime QueriedAt { get; set; }
        [Ignore]
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
