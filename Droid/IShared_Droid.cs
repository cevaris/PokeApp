using System;
using System.IO;
using Android.Content.Res;
using PokeApp.Utils;
using PokeApp.Droid;
using PokeApp.Data;
using SQLite;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(IShared_Droid))]
namespace PokeApp.Droid
{
    public class IShared_Droid : IShared
    {
        private static ILogger Logger = new ConsoleLogger("IShared_Droid");

        private static string ExternalDirectory =
            Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

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
            CopyAssets("AboutAssets.txt");
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
            //Logger.Info($"checking assets {assetManager.List("").ToString()}");
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
    }
}


