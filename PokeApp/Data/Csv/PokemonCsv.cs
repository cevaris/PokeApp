using System;
using PokeApp.Data.Tables;
using PokeApp.Utils;

namespace PokeApp.Data.Csv
{
    public class PokemonCsv : ICsvInfo<PokemonTable>
    {
        public string Filename()
        {
            return "pokemon.csv";
        }

        public PokemonTable FromCsv(string line)
        {
            //id,identifier,species_id,height,weight,base_experience,order,is_default
            //1,bulbasaur,1,7,69,64,1,1
            String[] data = line.Split(',');

            var instance = new PokemonTable
            {
                Id = TextUtils.ParseInt32(data[0]),
                Identifier = data[1],
                SpeciesId = TextUtils.ParseInt32(data[2]),
                Height = TextUtils.ParseInt32(data[3]),
                Weight = TextUtils.ParseInt32(data[4]),
                BaseExperience = TextUtils.ParseInt32(data[5]),
                IsDefault = TextUtils.ParseInt32(data[6])
            };

            return instance;
        }
    }
}
