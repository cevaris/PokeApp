using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PokeApp.Utils;

namespace PokeApp
{
    public class ResourceLoader
    {
        static readonly ILogger Logger = new ConsoleLogger("ResourceLoader");

        public static string GetResourceStream(string resourcePath)
        {
            var assembly = typeof(ResourceLoader).GetType().GetTypeInfo().Assembly;
            List<string> resourceNames = new List<string>(assembly.GetManifestResourceNames());
            foreach (string res in resourceNames)
            {
                Logger.Info("found resource: " + res);
            }


            string path = resourcePath.Replace(@"/", ".");
            path = resourceNames.FirstOrDefault(r => r.Contains(path));

            if (path == null)
                throw new FileNotFoundException($"Resource {resourcePath} not found");

            return path;
        }
    }
}
