using System;
using System.IO;
using SQLite;

namespace PokeApp.Utils
{
    public interface IShared
    {
        byte[] Md5(byte[] bytes);
        byte[] ToBytes(string message);

        string ToTitleCase(string str);

        SQLiteAsyncConnection GetAsyncConnection();
        string DatabasePath();

        string PokedexZipPath();
        string PokedexCsvPath();

        bool DoesFileExists(string filePath);
        StreamReader OpenReader(string filename);
        StreamWriter OpenWriter(string filename);

        void ShowBanner(string id);
        void HideKeyboard();
    }
}
