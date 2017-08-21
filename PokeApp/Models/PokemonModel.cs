namespace PokeApp
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
