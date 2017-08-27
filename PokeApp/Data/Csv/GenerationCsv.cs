﻿using System;
using PokeApp.Utils;

namespace PokeApp.Data.Csv
{
    public class GenerationCsv : ICsvInfo
    {
        public string Filename()
        {
            return "generation_names.csv";
        }

        public PokedexTable FromCsv(string line)
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
