using SQLite;

namespace PokeApp.Data
{
    public class HabitatTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }
    }
}
