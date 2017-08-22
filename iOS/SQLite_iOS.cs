using System;
using System.IO;
using PokeApp.iOS;
using PokeApp.Utils;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace PokeApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        private static ILogger Logger = new ConsoleLogger("SQLite_Android");

        public SQLite_iOS()
        {
        }

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            string pathFull = Path.Combine(libraryPath, PokeApp.Constants.DatabaseName);

            Logger.Info($"dbpath: {pathFull}");
            return pathFull;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string dbPath = GetDatabasePath();
            return new SQLiteAsyncConnection(dbPath);

        }
    }
}
