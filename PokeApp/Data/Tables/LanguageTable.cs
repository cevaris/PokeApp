using System;
using PokeApp.Utils;
using SQLite;

namespace PokeApp.Data
{
    public class LanguageTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Iso639 { get; set; }

        public string Iso3166 { get; set; }

        public string Identifier { get; set; }

        // actually a boolean
        public int Official { get; set; }

        public string Name { get; set; }


        public static PokedexTable FromCsv(string line)
        {
            String[] data = line.Split(',');

            //id,iso639,iso3166,identifier,official,order
            //1 ,ja    ,jp     ,ja-Hrkt   ,1       ,1
            var instance = new LanguageTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                Iso639 = data[1],
                Iso3166 = data[2],
                Identifier = data[3],
                Official = TextUtils.ParseInt32(data[4])
            };

            return instance;
        }
    }
}
