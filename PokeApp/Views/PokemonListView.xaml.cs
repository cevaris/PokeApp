using PokeApp.Data.Models;
using PokeApp.Data.Mappers;
using PokeApp.Data.Tables;
using Xamarin.Forms;
using PokeApp.Utils;
using System;

namespace PokeApp
{
    public partial class PokemonListView : ContentPage
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListView));

        public PokemonListView()
        {
            InitializeComponent();
            PokemonList = new ListView(ListViewCachingStrategy.RetainElement);
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            PokemonListItemModel p = ((PokemonListItemModel)e.Item);
            Logger.Info($"fired for {p.Id}-{p.Name}");
            MessagingCenter.Send<PokemonListView, ItemVisibilityEventArgs>(this, PokemonListViewModel.MessagePage, e);
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            PokemonListItemModel selectedPokemon = (PokemonListItemModel)e.SelectedItem;
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
                    PageWithQuery(args.NewTextValue);
                }
            }
        }

        private void PageWithQuery(string query)
        {
            MessagingCenter.Send<PokemonListView, string>(this, PokemonListViewModel.MessagePageWithQuery, query);
        }
    }

}
