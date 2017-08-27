using System;
using PokeApp.Utils;

namespace PokeApp.Data.Csv
{
    public class HabitatCsv : ICsvInfo
    {
        public string Filename()
        {
            return "pokemon_habitat_names.csv";
        }

        public PokedexTable FromCsv(string line)
        {
            String[] data = line.Split(',');

            var instance = new HabitatTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                LanguageId = TextUtils.ParseInt32(data[1]),
                Name = data[2]
            };

            return instance;
        }
    }
}
