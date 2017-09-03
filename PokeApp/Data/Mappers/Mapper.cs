using System;
using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Threading.Tasks;

namespace PokeApp.Data.Mappers
{
    public class Mapper
    {
        private static LanguageTable english;

        public Mapper()
        {
        }

        public static LanguageTable LanguageEnglish()
        {
            if (english == null)
            {
                var conn = App.Shared.GetAsyncConnection();
                Task<LanguageTable> task = conn.Table<LanguageTable>()
                             .Where(x => x.Iso639 == Constants.Locale)
                                  .FirstAsync();

                english = task.Result;
            }

            return english;
        }
    }
}
