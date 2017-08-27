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
                Task.Run(() =>
                {
                    Unzip();
                    ParseTables();
                    //Parse CSV to *Tables
                    //Save them to DB
                    //SaveToFile
                }).ConfigureAwait(false);
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
            List<PokedexTable> tables = new List<PokedexTable>();
            // LanguageId 9 is english
            // "pokemon_species.csv"  -> id, identifier, generation_id, evolution_chain_id, evolves_from_species_id, habitat_id, capture_rate
            // "pokemon_habitat_names.csv" -> id, local_language_id, name
            // "generation_names.csv" -> generation_id, local_language_id, name 

            return tables;
        }
    }
}
