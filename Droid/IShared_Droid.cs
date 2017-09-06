using System;
using System.IO;
using Android.Content.Res;
using PokeApp.Utils;
using PokeApp.Droid;
using PokeApp.Data;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Security;
using System.Text;
using System.Security.Cryptography;

[assembly: Dependency(typeof(IShared_Droid))]
namespace PokeApp.Droid
{
    public class IShared_Droid : IShared
    {
        private static ILogger Logger = new ConsoleLogger(nameof(IShared_Droid));

        private static string externalDirectory =
            Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

        private readonly static Encoding encoder = Encoding.Default;

        public IShared_Droid()
        {
            string dbLibPath = DatabasePath();
            if (!DoesFileExists(dbLibPath))
            {
                try
                {
                    copyAssets(Constants.DatabaseName);
                }
                catch (Java.IO.FileNotFoundException)
                {
                    Logger.Error($"{Constants.DatabaseName} asset not found");
                }
            }

            try
            {
                copyAssets(Constants.ZipName);
            }
            catch (Java.IO.FileNotFoundException)
            {
                Logger.Info($"{Constants.ZipName} asset not found");
            }
        }

        public string DatabasePath()
        {
            string pathFull = Path.Combine(externalDirectory, Constants.DatabaseName);
            return pathFull;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string dbPath = DatabasePath();
            return new SQLiteAsyncConnection(dbPath);
        }

        public string PokedexZipPath()
        {
            var filePath = Path.Combine(externalDirectory, Constants.ZipName);
            return filePath;
        }

        public string PokedexCsvPath()
        {
            var filePath = Path.Combine(externalDirectory, "extracted");
            return filePath;
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

        public bool DoesFileExists(string filePath)
        {
            return File.Exists(filePath);
        }


        // Local 
        private void copyAssets(string assetName)
        {
            AssetManager assetManager = Forms.Context.Assets;
            Logger.Info($"Looking for asset {assetName}");
            var outFilepath = Path.Combine(externalDirectory, assetName);

            using (Stream asset = assetManager.Open(assetName))
            {
                using (StreamWriter writer = new StreamWriter(outFilepath))
                {
                    asset.CopyTo(writer.BaseStream);
                    Logger.Info($"{assetName} written to {outFilepath} {new FileInfo(outFilepath).Length} bytes");
                }
            }
        }
    }
}


