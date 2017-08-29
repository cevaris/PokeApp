using SQLite;

namespace PokeApp.Data.Tables
{
    public class GenerationTable : PokedexTable
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }
    }
}
