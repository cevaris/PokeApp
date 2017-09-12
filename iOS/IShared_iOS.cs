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
        private static ILogger logger = new ConsoleLogger(nameof(IShared_iOS));

        private readonly Encoding encoder = Encoding.Default;

        private string bundlePath = NSBundle.MainBundle.BundlePath;

        private const bool shouldCopyBundleToLib = false;

        public IShared_iOS()
        {
            // copy over bundle resources to application Library
            string dbBundlePath = Path.Combine(bundlePath, Constants.DatabaseName);
            string dbLibPath = DatabasePath();
            if (DoesFileExists(dbBundlePath) && !DoesFileExists(dbLibPath))
            {
                copyToLibrary(dbBundlePath, dbLibPath);
            }
        }

        public string DatabasePath()
        {
            string dbLibPath = Path.Combine(GetLibraryPath(), Constants.DatabaseName);
            return dbLibPath;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string dbPath = DatabasePath();
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

        public bool DoesFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void ShowBanner(string id)
        {
        }

        private void copyToLibrary(string inFilePath, string outFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outFilePath))
            {
                using (Stream reader = File.OpenRead(inFilePath))
                {
                    reader.CopyTo(writer.BaseStream);
                    logger.Info($"{inFilePath} written {new FileInfo(outFilePath).Length} bytes to {outFilePath}");
                }
            }
        }
    }
}
