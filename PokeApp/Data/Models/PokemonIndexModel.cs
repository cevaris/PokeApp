using System;
using System.Collections.Generic;
using SQLite;

namespace PokeApp.Data.Models
{
    public class PokemonResourceList
    {
        public List<NamedApiResource> Results { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
