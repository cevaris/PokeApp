using System;
using PokeApp.Utils;
using PokeApp.Data.Tables;

namespace PokeApp.Data.Csv
{
    public class GenerationCsv : ICsvInfo<GenerationTable>
    {
        public string Filename()
        {
            return "generation_names.csv";
        }

        public GenerationTable FromCsv(string line)
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
