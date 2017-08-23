using System;
using SQLite;

namespace PokeApp
{
    public class PokemonModel
    {
        public string Name { get; set; }

        [PrimaryKey]
        public int Id { get; set; }
        public string IdDisplay
        {
            get
            {
                return $"#{Id}";
            }
        }

        [Indexed]
        public string URI { get; set; }

        public DateTime QueriedAt { get; set; }

        public string SpriteFront
        {
            get
            {
                return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
            }
        }
        public string SpriteBack
        {
            get
            {
                return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/{Id}.png";
            }
        }
    }
}
