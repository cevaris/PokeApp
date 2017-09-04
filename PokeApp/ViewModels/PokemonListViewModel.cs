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

        public ObservableCollection<PokemonBasicModel> PokemonList { get; set; }

        public string SearchQuery { get; set; }

        public static readonly string MessagePageWithQuery = $"{nameof(PokemonListViewModel)}.PageQuery";
        public static readonly string MessagePage = $"{nameof(PokemonListViewModel)}.Page";

        private CancellationTokenSource tokenSource { get; set; }

        public PokemonListViewModel()
        {
            PokemonList = new ObservableCollection<PokemonBasicModel>();

            MessagingCenter.Subscribe<PokedexStorage>(this, PokedexStorage.MessageReady, async (_) =>
            {
                await Update(idOffset: 0);
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
                    IsLoading = false;
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

        private async Task<int> Update(int idOffset, string nameQuery = null, bool clearList = false)
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
            await Task.Delay(1000, token);

            Logger.Info($"processing query: {query}");

            if (query != null)
                query = query.Trim().ToLower();

            SearchQuery = query;
            await Update(0, SearchQuery, clearList: true);
            return token;
        }

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(caller));
            }
        }
    }
}
