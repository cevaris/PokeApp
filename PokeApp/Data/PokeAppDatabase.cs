using SQLite;

namespace PokeApp
{
    public class PokeAppDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly ISQLite dbFactory;
        readonly Utils.ILogger Logger = new Utils.ConsoleLogger("PokeAppDatabase");

        public PokeAppDatabase(ISQLite dbFactory)
        {
            this.dbFactory = dbFactory;

            SQLitePCL.Batteries_V2.Init();

            database = dbFactory.GetAsyncConnection();
            database.CreateTableAsync<PokemonModel>().Wait();
        }

    }
}
