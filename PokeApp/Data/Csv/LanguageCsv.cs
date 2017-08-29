using System;
using PokeApp.Utils;
using PokeApp.Data.Tables;

namespace PokeApp.Data.Csv
{
    public class LanguageCsv : ICsvInfo<LanguageTable>
    {
        public string Filename()
        {
            return "languages.csv";
        }

        public LanguageTable FromCsv(string line)
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
