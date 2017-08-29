using SQLite;

namespace PokeApp.Data.Tables
{
    public class LanguageTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Iso639 { get; set; }

        public string Iso3166 { get; set; }

        public string Identifier { get; set; }

        // actually a boolean, 1=true, 0=false
        public int Official { get; set; }

        public string Name { get; set; }
    }
}
