using System;
using PokeApp.Utils;

namespace PokeApp.Data.Csv
{
    public class LanguageCsv : ICsvInfo
    {
        public string Filename()
        {
            return "languages.csv";
        }

        public PokedexTable FromCsv(string line)
        {
            String[] data = line.Split(',');

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
