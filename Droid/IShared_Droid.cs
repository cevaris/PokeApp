using System;
using System.IO;
using Android.Content.Res;
using PokeApp.Utils;
using PokeApp.Droid;
using PokeApp.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(IShared_Droid))]
namespace PokeApp.Droid
{
    public class IShared_Droid : IShared
    {
        private static ILogger Logger = new ConsoleLogger("IShared_Droid");

        public IShared_Droid()
        {
        }

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
            using (StreamReader sr = new StreamReader(assets.Open(Constants.ZipName)))
            {
                content = sr.ReadToEnd();
            }
            Logger.Info(content.Length);

            return "somepath";
        }

    }
}