﻿using System;
using System.IO;
using Xamarin.Forms;
using ICSharpCode.SharpZipLib.Zip;
using PokeApp.Utils;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokeApp.Data.Csv;

namespace PokeApp.Data
{
    public class PokedexStorage
    {
        readonly static ILogger Logger = new ConsoleLogger(nameof(PokedexStorage));

        private static PokedexStorage instance = new PokedexStorage();

        public static void Init()
        {
            if (App.Shared.PokedexCsvExists())
            {
                Logger.Info($"CsvPath exists {App.Shared.PokedexZipPath()}");
            }
            else
            {
                // Unzip, Parse, Write to DB
                Task.Run(() =>
                {
                    try
                    {
                        instance.Unzip();
                        instance.ParseTables();
                        //Save them to DB
                        //SaveToFile
                        Logger.Info("done init Pokedex data");
                    }
                    catch (Exception e)
                    {
                        Logger.Error("failed to init Pokedex data", e);
                    }
                }).ConfigureAwait(false);
            }
        }

        private void Unzip()
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

        private List<PokedexTable> ParseTables()
        {

            // LanguageId 9 is english
            // "pokemon_species.csv"  -> id, identifier, generation_id, evolution_chain_id, evolves_from_species_id, habitat_id, capture_rate
            // "pokemon_habitat_names.csv" -> id, local_language_id, name
            // "generation_names.csv" -> generation_id, local_language_id, name 

            List<PokedexTable> pokemonSpecies = ParseTable(new Csv.PokemonSpeciesCsv());
            List<PokedexTable> habbits = ParseTable(new HabitatCsv());
            List<PokedexTable> generations = ParseTable(new GenerationCsv());
            List<PokedexTable> languages = ParseTable(new LanguageCsv());

            return new List<PokedexTable>();
        }

        private List<PokedexTable> ParseTable(ICsvInfo csvInfo)
        {
            List<PokedexTable> tables = new List<PokedexTable>();
            string pokemonSpeciesPath = Path.Combine(App.Shared.PokedexCsvPath(), csvInfo.Filename());
            Logger.Info($"reading file {pokemonSpeciesPath}");

            using (StreamReader reader = App.Shared.OpenReader(pokemonSpeciesPath))
            {
                reader.ReadLine(); // ignore csv headers
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Logger.Info($"parsing line {line}");

                    PokedexTable table = csvInfo.FromCsv(line);
                    tables.Add(table);
                }
            }

            return tables;
        }
    }
}
