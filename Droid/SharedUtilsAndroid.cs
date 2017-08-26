using System;
using System.IO;
using Android.Content.Res;
using PokeApp.Utils;
using PokeApp.Droid;
using PokeApp.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SharedUtilsAndroid))]
namespace PokeApp.Droid
{
    public class SharedUtilsAndroid : SharedUtils
    {
        private static ILogger Logger = new ConsoleLogger("SharedUtilsAndroid");

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string pathFull = Path.Combine(documentsPath, Constants.DatabaseName);

            Logger.Info($"dbpath: {pathFull}");

            return pathFull;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string dbPath = GetDatabasePath();
            return new SQLiteAsyncConnection(dbPath);
        }

        public string PokemonZipPath()
        {
            AssetManager assets = Forms.Context.Assets;
            string content;
            using (StreamReader sr = new StreamReader(assets.Open("Pokedex.zip")))
            {
                content = sr.ReadToEnd();
            }
            System.Diagnostics.Debug.WriteLine(content.Length);


            return "somepath";
        }

    }
}