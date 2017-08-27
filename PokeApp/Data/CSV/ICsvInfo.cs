namespace PokeApp.Data.Csv
{
    public interface ICsvInfo
    {
        string Filename();
        PokedexTable FromCsv(string line);
    }
}
