using SQLite;

namespace PokeApp.Data
{
    public class HabitatTable : PokedexTable
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }
    }
}
