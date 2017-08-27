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

        public IShared_Droid()
        {
        }

        public string GetDatabasePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string pathFull = Path.Combine(documentsPath, Constants.DatabaseName);

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
            CopyAssets("AboutAssets.txt");
            CopyAssets(Constants.ZipName);

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, Constants.ZipName);
            return filePath;
        }

        public string PokemonCsvPath()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "extracted");
            return filePath;
        }



        // Local 
        private void CopyAssets(string assetName)
        {
            AssetManager assetManager = Forms.Context.Assets;
            //Logger.Info($"checking assets {assetManager.List("").ToString()}");

            //var foundAsset = assetManager.List(Constants.ZipName);

            //foreach (String filename in assetManager.List(""))
            //{
            //Logger.Info($"Looking for asset {assetName}  {assetManager.OpenFd(assetName).Length}");
            Logger.Info($"Looking for asset {assetName}");
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, assetName);

            //if (File.Exists(filePath))
            //{
            //    Logger.Info($"{filename} already written to {filePath} {new FileInfo(filePath).Length}");
            //    continue; // skip if file already written
            //}
            //else
            //{
            //    Logger.Info($"{filename} needs to be written");
            //}

            //using (var reader = new StreamReader(assetManager.Open(Constants.ZipName)))
            //{
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (Stream asset = assetManager.Open(assetName))
                {
                    asset.CopyTo(writer.BaseStream);
                    Logger.Info($"{assetName} written to {filePath} {new FileInfo(filePath).Length} bytes");
                }
            }
            //}

            //}
        }
    }
}


