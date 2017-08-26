using System;
using System.IO;
using PokeApp.Data;
using PokeApp.iOS;
using PokeApp.Utils;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(IShared_iOS))]
namespace PokeApp.iOS
{
    public class IShared_iOS : IShared
    {
        private static ILogger Logger = new ConsoleLogger("SQLite_Android");

        public IShared_iOS()
        {
        }

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            string pathFull = Path.Combine(libraryPath, Constants.DatabaseName);

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
            return "Pokedex.zip";
        }
    }
}
