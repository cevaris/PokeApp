using PokeApp.Data.Tables;
using PokeApp.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Utils;
using System.Linq;
using System.Threading.Tasks;
using PokeApp.Data.Mappers;
using PokeApp.Data.Models;
using System.Threading;
using System;

namespace PokeApp
{
    public class PokemonListViewModel
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListViewModel));

        public bool IsLoading { get; set; }

        public ObservableCollection<PokemonBasicModel> PokemonList { get; set; }

        public string SearchQuery { get; set; }

        public static readonly string MessagePageWithQuery = $"{nameof(PokemonListViewModel)}.PageQuery";
        public static readonly string MessagePage = $"{nameof(PokemonListViewModel)}.Page";

        private CancellationTokenSource tokenSource { get; set; }

        public PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>();
            IsLoading = true;

            tokenSource = new CancellationTokenSource();

            MessagingCenter.Subscribe<PokedexStorage>(this, PokedexStorage.MessageReady, async (_) =>
            {
                await Update(0, null);
            });

            MessagingCenter.Subscribe<PokemonListView, string>(this, MessagePageWithQuery, async (sender, query) =>
            {
                Logger.Info($"queing query: {query}");
                try
                {
                    tokenSource?.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    Logger.Info($"token source alredy disposed");
                }

                try
                {
                    tokenSource = new CancellationTokenSource();
                    await QueryTask(query, tokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    Logger.Info($"cancelled query: {query}");
                }

            });

            MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, MessagePage, async (sender, e) =>
            {
                if (PokemonList.Count > 0 && (PokemonBasicModel)e.Item == PokemonList.Last())
                {
                    await Update(((PokemonBasicModel)e.Item).Id + 1, SearchQuery);
                }
            });
        }

        public static PokemonListViewModel Preview = new PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>(){
                new PokemonBasicModel()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    SpriteUrl = PokeUtils.GetImage(1)
                },
                new PokemonBasicModel()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    SpriteUrl = PokeUtils.GetImage(2)
                }
            }

        };

        private async Task<int> Update(int idOffset, string nameQuery, bool clearList = false)
        {
            IsLoading = true;
            List<PokemonBasicModel> pageResults = await PokemonBasicMapper.Page(idOffset, nameQuery);
            if (clearList)
            {
                PokemonList.Clear();
            }

            foreach (PokemonBasicModel p in pageResults)
            {
                PokemonList.Add(p);
            }
            IsLoading = false;
            return pageResults.Count;
        }

        private async Task<CancellationToken> QueryTask(string query, CancellationToken token)
        {
            // https://stackoverflow.com/a/35165414/3538289
            await Task.Delay(1000, token);

            Logger.Info($"processing query: {query}");

            if (query != null)
                query = query.Trim().ToLower();

            SearchQuery = query;
            await Update(0, SearchQuery, clearList: true);
            return token;
        }
    }
}
