using PokeApp.Utils;

namespace PokeApp
{
    public class PokeAppDatabase
    {
        readonly ILogger Logger = new ConsoleLogger(nameof(PokeAppDatabase));

        public PokeAppDatabase()
        {
        }
    }
}
