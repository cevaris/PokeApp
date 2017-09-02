using System;
using System.IO;
using SQLite;

namespace PokeApp.Utils
{
    public interface IShared
    {
        byte[] Md5(byte[] bytes);
        byte[] ToBytes(string message);

        SQLiteAsyncConnection GetAsyncConnection();
        string GetDatabasePath();

        string PokedexZipPath();
        string PokedexCsvPath();
        bool PokedexCsvExists();

        StreamReader OpenReader(string filename);
        StreamWriter OpenWriter(string filename);
    }
}
