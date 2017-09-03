using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Foundation;
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
        private readonly static Encoding encoder = Encoding.Default;

        public IShared_iOS()
        {
        }

        public string GetDatabasePath()
        {
            string pathFull = Path.Combine(GetLibraryPath(), Constants.DatabaseName);
            return pathFull;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string dbPath = GetDatabasePath();
            return new SQLiteAsyncConnection(dbPath);
        }

        public string PokedexZipPath()
        {
            string documentsPath = NSBundle.MainBundle.BundlePath;
            string pathFull = Path.Combine(documentsPath, "Pokedex.zip");
            return pathFull;
        }

        public string PokedexCsvPath()
        {
            string pathFull = Path.Combine(GetLibraryPath(), "extracted");
            return pathFull;
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

        public byte[] Md5(byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes);
        }

        public byte[] ToBytes(string message)
        {
            return encoder.GetBytes(message);
        }

        public string ToTitleCase(string str)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        private string GetLibraryPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            return libraryPath;
        }
    }
}
