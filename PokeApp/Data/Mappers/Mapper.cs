using System;
using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Threading.Tasks;

namespace PokeApp.Data.Mappers
{
    public class Mapper
    {
        public Mapper()
        {

        }

        protected static async Task<LanguageTable> LanguageEnglish()
        {
            var conn = App.Shared.GetAsyncConnection();
            return await conn.Table<LanguageTable>()
                             .Where(x => x.Iso639 == Constants.Locale)
                             .FirstAsync();
        }
    }
}
