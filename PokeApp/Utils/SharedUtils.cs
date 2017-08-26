using SQLite;

namespace PokeApp.Utils
{
    public interface SharedUtils
    {
        SQLiteAsyncConnection GetAsyncConnection();
        string GetDatabasePath();
        string PokemonZipPath();
    }
}
