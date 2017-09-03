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

            //var de = NSFileManager.DefaultManager;
            //var error = new NSError();
            //foreach (string f in de.GetDirectoryContent(NSBundle.MainBundle.BundlePath, out error))
            //{
            //    Logger.Info(f);
            //}

            //foreach (string f in Directory.EnumerateFiles(NSBundle.MainBundle.BundlePath))
            //{
            //    Logger.Info(f);
            //}



            //NSBundle.MainBundle.PathForResource("pokedex", "zip");

            string documentsPath = NSBundle.MainBundle.BundlePath; // Documents folder
                                                                   //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder

            //foreach (string f in Directory.EnumerateFiles(documentsPath))
            //{
            //    Logger.Info(f);
            //}

            //foreach (string f in Directory.EnumerateFiles(Path.Combine(documentsPath, "..")))
            //{
            //    Logger.Info(f);
            //}
            //foreach (string f in Directory.EnumerateFiles(libraryPath))
            //{
            //    Logger.Info(f);
            //}

            string pathFull = Path.Combine(documentsPath, "Pokedex.zip");
            Logger.Info(File.Exists(pathFull));
            return pathFull;
            //return "Pokedex.zip";
        }

        public string PokedexCsvPath()
        {
            //string documentsPath = NSBundle.MainBundle.BundlePath;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            string pathFull = Path.Combine(libraryPath, "extracted");
            //string pathFull = Path.Combine(documentsPath, "extracted");
            return pathFull;
            //return "extracted";
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
    }
}
