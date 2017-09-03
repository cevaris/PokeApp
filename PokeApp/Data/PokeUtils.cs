using System;
using System.Text;
using PokeApp.Utils;

namespace PokeApp.Data
{
    public class PokeUtils
    {
        private static readonly ILogger logger = new ConsoleLogger(nameof(PokeUtils));

        public static string GetImage(int id)
        {
            string message = $"{id}-{Secrets.Salt}";
            byte[] bytes = App.Shared.ToBytes(message);
            byte[] buffer = App.Shared.Md5(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                sb.Append(buffer[i].ToString("x2"));
            }
            string hash = sb.ToString();
            string url = $"https://s3-us-west-2.amazonaws.com/pokeapp.assets/images/{hash}.png";
            logger.Info(url);
            return url;
        }
    }
}