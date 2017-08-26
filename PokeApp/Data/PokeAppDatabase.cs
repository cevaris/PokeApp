using PokeApp.Models;
using PokeApp.Utils;
using SQLite;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace PokeApp
{
    public class PokeAppDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly IShared dbFactory;
        readonly ILogger Logger = new ConsoleLogger("PokeAppDatabase");

        public PokeAppDatabase(IShared dbFactory)
        {
            
            // https://github.com/escamoteur/TBInfrastructure/blob/7363fcab59b44654eee4fee3d89eccaae66e1c7c/FileStorage.cs#L128

            //Assembly assembly = typeof(PokeAppDatabase).GetType().GetTypeInfo().Assembly;
            //Stream stream  = assembly.GetManifestResourceStream("Resources/Pokedex.zip");

            //var zipStream = new ZipInputStream(stream);
            //var zipfile = new ZipFile("Resources/Pokedex.zip");

            //var zipEntry = zipStream.GetNextEntry();
            //Logger.Info(zipEntry.Name);

            //var test = new ZipFile(stream);

            
            FastZipEvents events = new FastZipEvents();
            events.Progress += (object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e) => {
                Logger.Info($"{e.Name} - {e.PercentComplete}");
            };
            FastZip fastzip = new FastZip(events);
            //fastzip.ExtractZip("Pokedex.zip", "extracted", @"\.csv$");


            //this.dbFactory = dbFactory;
            //SQLitePCL.Batteries_V2.Init();

            //database = dbFactory.GetAsyncConnection();

            //// url -> json blob mapping
            //database.CreateTableAsync<ResourceModel>().Wait();
        }
    }
}
