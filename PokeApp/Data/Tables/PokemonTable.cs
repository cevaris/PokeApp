using System;
namespace PokeApp.Data.Tables
{
    public class PokemonTable : PokedexTable
    {
        //id,identifier,species_id,height,weight,base_experience,order,is_default
        //1,bulbasaur,1,7,69,64,1,1

        [SQLite.PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int SpeciesId { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int BaseExperience { get; set; }

        // boolean
        public int IsDefault { get; set; }
    }
}
