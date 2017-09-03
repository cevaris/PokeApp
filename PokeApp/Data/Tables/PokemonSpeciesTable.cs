using System;

namespace PokeApp.Data.Tables
{

    public class PokemonSpeciesTable : PokedexTable
    {
        [SQLite.PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int GenerationId { get; set; }

        public Nullable<int> EvolutionChainId { get; set; }

        public Nullable<int> EvolvesFromSpeciesId { get; set; }

        public Nullable<int> HabitatId { get; set; }

        public int CaptureRate { get; set; }
    }
}
