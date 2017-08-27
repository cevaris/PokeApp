using System;
using PokeApp.Utils;
using SQLite;

namespace PokeApp.Data
{
    public class GenerationTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }


        public static PokedexTable FromCsv(string line)
        {
            String[] data = line.Split(',');

            var instance = new GenerationTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                LanguageId = TextUtils.ParseInt32(data[1]),
                Name = data[2]
            };

            return instance;
        }
    }
}
