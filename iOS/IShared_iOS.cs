using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
        private static ILogger Logger = new ConsoleLogger(nameof(IShared_iOS));

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

        public string PokedexZipPath()
        {
            return "Pokedex.zip";
        }

        public string PokedexCsvPath()
        {
            return "extracted";
        }

        public bool PokedexCsvExists()
        {
            return File.Exists(PokedexCsvPath());
        }

        public StreamReader OpenReader(string filename)
        {
            return new StreamReader(filename);
        }

        public StreamWriter OpenWriter(string filename)
        {
            return new StreamWriter(filename);
        }

        public string Md5(string message)
        {
            Encoding encoding = Encoding.Default;
            MD5 result = System.Security.Cryptography.MD5.Create();
            var buffer = result.ComputeHash(encoding.GetBytes($"{message}-{Secrets.Salt}"));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
