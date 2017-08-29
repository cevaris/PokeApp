namespace PokeApp.Data.Tables
{
    public class PokemonSpeciesNameTable : PokedexTable
    {
        [SQLite.Indexed]
        public int Id { get; set; }

        [SQLite.Indexed]
        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string Genus { get; set; }
    }
}
