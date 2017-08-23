using PokeApp.Models;
using PokeApp.Utils;
using SQLite;

namespace PokeApp
{
    public class PokeAppDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly ISQLite dbFactory;
        readonly ILogger Logger = new ConsoleLogger("PokeAppDatabase");

        public PokeAppDatabase(ISQLite dbFactory)
        {
            this.dbFactory = dbFactory;

            SQLitePCL.Batteries_V2.Init();

            database = dbFactory.GetAsyncConnection();

            // url -> json blob mapping
            database.CreateTableAsync<ResourceModel>().Wait();
        }

    }
}
