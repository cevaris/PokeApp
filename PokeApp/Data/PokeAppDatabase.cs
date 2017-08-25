using PokeApp.Models;
using PokeApp.Utils;
using SQLite;
using System.IO;
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
        readonly ISQLite dbFactory;
        readonly ILogger Logger = new ConsoleLogger("PokeAppDatabase");

        public PokeAppDatabase(ISQLite dbFactory)
        {
            String pokedexZipPath = ResourceLoader.GetResourceStream(@"Pokedex.zip");
            FastZip fastzip = new FastZip(new FastZipEvents());
            fastzip.ExtractZip("zipFile", "directory to unzip", "*.csv");


            //this.dbFactory = dbFactory;
            //SQLitePCL.Batteries_V2.Init();

            //database = dbFactory.GetAsyncConnection();

            //// url -> json blob mapping
            //database.CreateTableAsync<ResourceModel>().Wait();
        }

       

    }
}
