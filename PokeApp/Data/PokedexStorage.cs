using System;
using System.IO;
using Xamarin.Forms;
using ICSharpCode.SharpZipLib.Zip;
using PokeApp.Utils;

namespace PokeApp.Data
{
    public class PokedexStorage
    {
        readonly static ILogger Logger = new ConsoleLogger(nameof(PokedexStorage));

        public PokedexStorage()
        {
        }

        public static void Init()
        {
            if (App.Shared.PokedexCsvExists())
            {
                Logger.Info($"CsvPath exists {App.Shared.PokedexZipPath()}");
            }
            else
            {
                Unzip();
                // Parse CSV to *Tables
                // Save them to DB
            }
        }


        private static void Unzip()
        {
            var path = App.Shared.PokedexZipPath();
            Logger.Info($"found zip path {path}");

            FastZipEvents events = new FastZipEvents();
            events.Progress += (object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e) =>
            {
                Logger.Info($"{e.Name} - {e.PercentComplete}");
            };
            FastZip fastzip = new FastZip(events);
            fastzip.ExtractZip(path, App.Shared.PokedexCsvPath(), @"\.csv$");
        }
    }
}
