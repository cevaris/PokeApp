using System;
using System.Threading.Tasks;
using PokeApp.Data.Models;
using PokeApp.Data.Tables;

namespace PokeApp.Data.Mappers
{
    public class PokemonMapper
    {
        public static async Task<PokemonModel> ToModel()
        {
            var conn = App.Shared.GetAsyncConnection();

            PokemonSpeciesTable species = await conn.Table<PokemonSpeciesTable>().FirstAsync();

            //return Task<PokemonModel>.Factory.StartNew(() => new PokemonModel());


            //return new Task<PokemonModel>(new PokemonModel());
            ///return Task.Run(;
            return new PokemonModel();
        }
    }
}
