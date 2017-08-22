using System;
using System.IO;
using PokeApp.Droid;
using PokeApp.Utils;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace PokeApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        private static ILogger Logger = new ConsoleLogger("SQLite_Android");

        public SQLite_Android()
        {
        }

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string pathFull = Path.Combine(documentsPath, PokeApp.Constants.DatabaseName);

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