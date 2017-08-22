using SQLite;

namespace PokeApp
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
        string GetDatabasePath();
    }
}
