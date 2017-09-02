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

        private static string ExternalDirectory =
            Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        
        private readonly static Encoding encoder = Encoding.Default;

        public IShared_Droid()
        {
        }

        public string GetDatabasePath()
        {
            string pathFull = Path.Combine(ExternalDirectory, Constants.DatabaseName);

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
            CopyAssets(Constants.ZipName);

            var filePath = Path.Combine(ExternalDirectory, Constants.ZipName);
            return filePath;
        }

        public string PokedexCsvPath()
        {
            var filePath = Path.Combine(ExternalDirectory, "extracted");
            return filePath;
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

        // Local 
        private void CopyAssets(string assetName)
        {
            AssetManager assetManager = Forms.Context.Assets;
            Logger.Info($"Looking for asset {assetName}");
            var filePath = Path.Combine(ExternalDirectory, assetName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (Stream asset = assetManager.Open(assetName))
                {
                    asset.CopyTo(writer.BaseStream);
                    Logger.Info($"{assetName} written to {filePath} {new FileInfo(filePath).Length} bytes");
                }
            }
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
    }
}


