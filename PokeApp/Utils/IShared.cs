using SQLite;

namespace PokeApp.Utils
{
    public interface IShared
    {
        SQLiteAsyncConnection GetAsyncConnection();
        string GetDatabasePath();
        string PokemonZipPath();
    }
}
