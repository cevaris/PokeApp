﻿using System;
using System.IO;
using Xamarin.Forms;
using ICSharpCode.SharpZipLib.Zip;
using PokeApp.Utils;
using System.Threading.Tasks;
using System.Collections.Generic;
using PokeApp.Data.Csv;
using SQLite;
using PokeApp.Data.Tables;

namespace PokeApp.Data
{
    public class PokedexStorage
    {
        readonly static ILogger Logger = new ConsoleLogger(nameof(PokedexStorage));

        private static PokedexStorage instance = new PokedexStorage();

        public const string MessageReady = "PokedexStorage.Ready";

        public static void Init()
        {
            if (App.Shared.DoesFileExists(App.Shared.PokedexZipPath()))
            {
                // Unzip, Parse, Write to DB
                Task.Run(() =>
                {
                    try
                    {
                        instance.Unzip();
                        instance.ParseAndPersistTables();
                        Logger.Info("done init Pokedex data");

                        MessagingCenter.Send<PokedexStorage>(instance, MessageReady);
                    }
                    catch (AggregateException e)
                    {
                        Logger.Error("failed to init Pokedex data", e);
                    }
                }).ConfigureAwait(false);
            }

            if (!App.Shared.DoesFileExists(App.Shared.DatabasePath()))
            {
                string msg = $"Database file {App.Shared.DatabasePath()} not found; failed to generate or not bundled";
                Logger.Error(msg);
                throw new IOException(msg);
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

        private void ParseAndPersistTables()
        {
            // LanguageId 9 is english
            // "pokemon_species.csv"  -> id, identifier, generation_id, evolution_chain_id, evolves_from_species_id, habitat_id, capture_rate
            // "pokemon_habitat_names.csv" -> id, local_language_id, name
            // "generation_names.csv" -> generation_id, local_language_id, name 
            // "pokemon_species_names.csv" -> pokemon_species_id,local_language_id,name,genus
            // "pokemon.csv" -> id,identifier,species_id,height,weight,base_experience,order,is_default

            SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();

            Task speciesTask = Task.Run(() =>
            {
                conn.DropTableAsync<PokemonSpeciesTable>().Wait();
                conn.CreateTableAsync<PokemonSpeciesTable>().Wait();
                List<PokemonSpeciesTable> pokemonSpecies = ParseTable(new PokemonSpeciesCsv());
                conn.InsertAllAsync(pokemonSpecies).Wait();
            });

            Task pokemonTask = Task.Run(() =>
            {
                conn.DropTableAsync<PokemonTable>().Wait();
                conn.CreateTableAsync<PokemonTable>().Wait();
                List<PokemonTable> pokemon = ParseTable(new PokemonCsv());
                conn.InsertAllAsync(pokemon).Wait();
            });

            Task speciesNamesTask = Task.Run(() =>
            {
                conn.DropTableAsync<PokemonSpeciesNameTable>().Wait();
                conn.CreateTableAsync<PokemonSpeciesNameTable>().Wait();
                List<PokemonSpeciesNameTable> pokemonSpeciesNames = ParseTable(new PokemonSpeciesNameCsv());
                conn.InsertAllAsync(pokemonSpeciesNames).Wait();
            });


            Task habbitTask = Task.Run(() =>
            {
                conn.DropTableAsync<HabitatTable>().Wait();
                conn.CreateTableAsync<HabitatTable>().Wait();
                List<HabitatTable> habbits = ParseTable(new HabitatCsv());
                conn.InsertAllAsync(habbits).Wait();
            });

            Task generationTask = Task.Run(() =>
            {
                conn.DropTableAsync<GenerationTable>().Wait();
                conn.CreateTableAsync<GenerationTable>().Wait();
                List<GenerationTable> generations = ParseTable(new GenerationCsv());
                conn.InsertAllAsync(generations).Wait();
            });

            Task languageTask = Task.Run(() =>
            {
                conn.DropTableAsync<LanguageTable>().Wait();
                conn.CreateTableAsync<LanguageTable>().Wait();
                List<LanguageTable> languages = ParseTable(new LanguageCsv());
                conn.InsertAllAsync(languages).Wait();
            });

            Task.WhenAll(new Task[]{
                speciesTask,
                speciesNamesTask,
                pokemonTask,
                habbitTask,
                generationTask,
                languageTask
            }).Wait();
        }

        private List<T> ParseTable<T>(ICsvInfo<T> csvInfo) where T : PokedexTable
        {
            List<T> tables = new List<T>();
            string pokemonSpeciesPath = Path.Combine(App.Shared.PokedexCsvPath(), csvInfo.Filename());
            Logger.Info($"reading file {pokemonSpeciesPath}");

            using (StreamReader reader = App.Shared.OpenReader(pokemonSpeciesPath))
            {
                reader.ReadLine(); // ignore csv headers
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    T table = csvInfo.FromCsv(line);
                    tables.Add(table);
                }
            }

            Logger.Info($"found {tables.Count} records in {csvInfo.Filename()}");
            return tables;
        }
    }
}
