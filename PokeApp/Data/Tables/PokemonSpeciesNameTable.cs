using SQLite;

namespace PokeApp.Data
{
    public class PokemonSpeciesNameTable : PokedexTable
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string Genus { get; set; }
    }
}
