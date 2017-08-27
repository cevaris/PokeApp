using System;
using System.IO;
using Xamarin.Forms;
using ICSharpCode.SharpZipLib.Zip;
using PokeApp.Utils;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PokeApp.Data
{
    public class PokedexStorage
    {
        readonly static ILogger Logger = new ConsoleLogger(nameof(PokedexStorage));

        const string PokemonSpeciesCsvName = "pokemon_species.csv";
        const string HabbitNamesCsvName = "pokemon_habitat_names.csv";
        const string GenerationNamesCsvName = "generation_names.csv";
        const string LanguagesCsvName = "languages.csv";


        public PokedexStorage()
        {
        }

        public static void Init()
        {
            if (App.Shared.PokedexCsvExists())
            {
                Logger.Info($"CsvPath exists {App.Shared.PokedexZipPath()}");
            }
            else
            {
                // Unzip, Parse, Write to DB
                //Task.Run(() =>
                //{
                    Unzip();
                    ParseTables();
                    //Save them to DB
                    //SaveToFile
                //}).ConfigureAwait(false);
            }
        }


        private static void Unzip()
        {
            var path = App.Shared.PokedexZipPath();
            Logger.Info($"found zip path {path}");

            FastZipEvents events = new FastZipEvents();
            events.Progress += (object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e) =>
            {
                Logger.Info($"{e.Name} - {e.PercentComplete}");
            };
            FastZip fastzip = new FastZip(events);
            fastzip.ExtractZip(path, App.Shared.PokedexCsvPath(), @"\.csv$");
        }

        private static List<PokedexTable> ParseTables()
        {
            
            // LanguageId 9 is english
            // "pokemon_species.csv"  -> id, identifier, generation_id, evolution_chain_id, evolves_from_species_id, habitat_id, capture_rate
            // "pokemon_habitat_names.csv" -> id, local_language_id, name
            // "generation_names.csv" -> generation_id, local_language_id, name 

            List<PokedexTable> pokemonSpecies = ParseTable(PokemonSpeciesCsvName, PokemonSpeciesTable.FromCsv);
            List<PokedexTable> habbits = ParseTable(HabbitNamesCsvName, HabitatTable.FromCsv);
            List<PokedexTable> generations = ParseTable(GenerationNamesCsvName, GenerationTable.FromCsv);
            List<PokedexTable> languages = ParseTable(LanguagesCsvName, LanguageTable.FromCsv);

            return new List<PokedexTable>();
        }

        private static List<PokedexTable> ParseTable(string filename, Func<String, PokedexTable> FromCsv)
        {
            List<PokedexTable> tables = new List<PokedexTable>();
            string pokemonSpeciesPath = Path.Combine(App.Shared.PokedexCsvPath(), filename);
            Logger.Info($"reading file {pokemonSpeciesPath}");

            using (StreamReader reader = App.Shared.OpenReader(pokemonSpeciesPath))
            {
                reader.ReadLine(); // ignore csv headers
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Logger.Info($"parsing line {line}");

                    PokedexTable table = FromCsv(line);
                    tables.Add(table);
                }
            }

            return tables;
        }
    }
}
