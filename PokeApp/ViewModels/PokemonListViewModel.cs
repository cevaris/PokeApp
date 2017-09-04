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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokeApp
{
    public class PokemonListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ILogger Logger = new ConsoleLogger(nameof(PokemonListViewModel));

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PokemonListItemModel> PokemonList { get; set; }

        public string SearchQuery { get; set; }

        public static readonly string MessagePageWithQuery = $"{nameof(PokemonListViewModel)}.PageQuery";
        public static readonly string MessagePage = $"{nameof(PokemonListViewModel)}.Page";

        private CancellationTokenSource tokenSource { get; set; }

        public PokemonListViewModel(bool subscribe = true)
        {
            PokemonList = new ObservableCollection<PokemonListItemModel>();

            if (subscribe)
            {
                MessagingCenter.Subscribe<PokedexStorage>(this, PokedexStorage.MessageReady, async (_) =>
                {
                    await Update(idOffset: 0, pageSize: 20);
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
                        if (query == null)
                        {
                            // query was closed/cancelled, reset list
                            SearchQuery = query;
                            await Update(idOffset: 0, pageSize: 20, clearList: true);
                        }
                        else
                        {
                            // there still is some text, reset stuff
                            tokenSource = new CancellationTokenSource();
                            await DelayedQueryTask(query, tokenSource.Token);
                            tokenSource.Dispose();
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        Logger.Info($"cancelled query: {query}");
                    }

                });

                MessagingCenter.Subscribe<PokemonListView, ItemVisibilityEventArgs>(this, MessagePage, async (sender, e) =>
                {
                    if (PokemonList.Count > 0 && (PokemonListItemModel)e.Item == PokemonList.Last())
                    {
                        await Update(((PokemonListItemModel)e.Item).Id + 1, SearchQuery);
                    }
                });
            }
        }

        public static PokemonListViewModel Preview = new PokemonListViewModel(subscribe: false)
        {
            PokemonList = new ObservableCollection<PokemonListItemModel>(){
                new PokemonListItemModel()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    SpriteUrl = PokeUtils.GetImage(1)
                },
                new PokemonListItemModel()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    SpriteUrl = PokeUtils.GetImage(2)
                }
            },


        };

        private async Task<int> Update(
            int idOffset,
            string query = null,
            bool clearList = false,
            int pageSize = 5
        )
        {
            Logger.Info($"idOffset:{idOffset}, query:{query} clearList:{clearList} pageSize:{pageSize}");
            IsLoading = true;
            List<PokemonListItemModel> pageResults = await PokemonListItemMapper.Page(idOffset, query, pageSize);
            if (clearList)
            {
                PokemonList.Clear();
            }

            foreach (PokemonListItemModel p in pageResults)
            {
                PokemonList.Add(p);
            }
            IsLoading = false;
            return pageResults.Count;
        }

        private async Task<CancellationToken> DelayedQueryTask(string query, CancellationToken token)
        {
            await Task.Delay(1000, token);
            await QueryTask(query);
            return token;
        }

        private async Task<string> QueryTask(string query)
        {
            Logger.Info($"processing query: {query}");

            if (query != null)
                query = query.Trim().ToLower();

            SearchQuery = query;
            await Update(idOffset: 0, query: query, clearList: true, pageSize: 20);
            return query;
        }

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
