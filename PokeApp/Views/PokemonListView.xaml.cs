using PokeApp.Data.Models;
using PokeApp.Data.Mappers;
using PokeApp.Data.Tables;
using Xamarin.Forms;
using PokeApp.Utils;
using System;

namespace PokeApp
{
    public partial class PokemonListView : StackLayout
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListView));

        public PokemonListView()
        {
            InitializeComponent();
            PokemonList = new ListView(ListViewCachingStrategy.RetainElement);
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            Logger.Info($"fired {e.Item.ToString()}");
            MessagingCenter.Send<PokemonListView, ItemVisibilityEventArgs>(this, PokemonListViewModel.MessagePage, e);
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            PokemonBasicModel selectedPokemon = (PokemonBasicModel)e.SelectedItem;
            if (selectedPokemon != null)
            {
                PokemonDetailPage page = new PokemonDetailPage();
                PokemonModel pokemon = await PokemonMapper.GetById(selectedPokemon.Id);
                page.BindingContext = new PokemonDetailViewModel()
                {
                    Pokemon = pokemon
                };
                await Navigation.PushAsync(page);
            }
        }

        public void OnButtonClick(object sender, EventArgs args)
        {
            if (sender == PokemonQuery)
            {
                Logger.Info(PokemonQuery.Text);
                PageWithQuery(PokemonQuery.Text);
            }
        }

        public void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender == PokemonQuery)
            {
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    PageWithQuery(null);
                }
                else
                {
                    Logger.Info(args.NewTextValue);
                    PageWithQuery(PokemonQuery.Text);
                }
            }
        }

        private void PageWithQuery(string query)
        {
            MessagingCenter.Send<PokemonListView, string>(this, PokemonListViewModel.MessagePageWithQuery, query);
        }
    }

}
