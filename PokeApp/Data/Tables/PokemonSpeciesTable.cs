using SQLite;

namespace PokeApp.Data
{

    public class PokemonSpeciesTable : PokedexTable
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int GenerationId { get; set; }

        public int? EvolutionChainId { get; set; }

        public int? EvolvesFromSpeciesId { get; set; }

        public int? HabitatId { get; set; }

        public int CaptureRate { get; set; }

    }
}
