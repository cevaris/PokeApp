using System;
using SQLitePCL;
using SQLite;
using Xamarin.Forms;

namespace PokeApp
{
    public class PokeAppDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly ISQLite dbFactory;

        public PokeAppDatabase(ISQLite dbFactory)
        {
            this.dbFactory = dbFactory;

            SQLitePCL.Batteries_V2.Init();

            database = dbFactory.GetAsyncConnection();
            database.CreateTableAsync<PokemonModel>().Wait();
        }
    }
}
