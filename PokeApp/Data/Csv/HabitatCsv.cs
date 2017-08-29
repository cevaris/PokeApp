using System;
using PokeApp.Utils;
using PokeApp.Data.Tables;

namespace PokeApp.Data.Csv
{
    public class HabitatCsv : ICsvInfo<HabitatTable>
    {
        public string Filename()
        {
            return "pokemon_habitat_names.csv";
        }

        public HabitatTable FromCsv(string line)
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
