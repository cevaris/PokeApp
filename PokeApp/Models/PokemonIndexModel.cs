using System;
using System.Collections.Generic;
using SQLite;

namespace PokeApp.Models
{
    public class PokemonIndexesModel
    {
        public List<PokemonIndexModel> Results { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }
    }

    public class PokemonIndexModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
