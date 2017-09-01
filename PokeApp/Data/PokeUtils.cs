using System;
using System.Text;

namespace PokeApp.Data
{
    public class PokeUtils
    {
        public static string GetImage(int id)
        {
            var hash = App.Shared.Md5(id.ToString());
            //var buffer = md5.ComputeHash(unicode.GetBytes($"{id}-{Salt}"));
            //string hex = unicode.GetString(buffer, 0, buffer.Length);
            string url = $"https://s3-us-west-2.amazonaws.com/pokemon/images/{hash}.png";
            return url;
        }
    }
}