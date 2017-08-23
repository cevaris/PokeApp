using System;
using System.Collections.Generic;
using SQLite;

namespace PokeApp.Models
{

    public class PokemonIndexModels
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime QueriedAt { get; set; }

        public List<PokemonIndexModel> results;

        public string Next { get; set; }
        public string Previous { get; set; }
    }

    public class PokemonIndexModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [Indexed]
        public string Url { get; set; }

        public DateTime QueriedAt { get; set; }

        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
