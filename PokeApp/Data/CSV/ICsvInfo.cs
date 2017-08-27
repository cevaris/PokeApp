namespace PokeApp.Data.Csv
{
    public interface ICsvInfo<T> where T : PokedexTable
    {
        string Filename();
        T FromCsv(string line);
    }
}
