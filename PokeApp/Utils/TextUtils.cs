using System;
namespace PokeApp.Utils
{
    public class TextUtils
    {
        static readonly ILogger Logger = new ConsoleLogger(nameof(TextUtils));

        public static int ParseInt32(string value)
        {
            try
            {
                return Int32.Parse(value);
            }
            catch (FormatException e)
            {
                Logger.Error($"failed to parse {value}", e);
                throw e;
            }
        }

        public static int? ParseNInt32(string value)
        {
            int result;
            if (Int32.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
