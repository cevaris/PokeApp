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
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListViewModel));

        public PokemonListView()
        {
            InitializeComponent();
            PokemonList = new ListView(ListViewCachingStrategy.RetainElement);
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            Logger.Info($"fired {e.Item.ToString()}");
            MessagingCenter.Send<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonListViewModel.Page", e);
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
            if (sender == searchBar)
            {
                Logger.Info(searchBar.Text);
                //itemListView.ItemsSource = Emails.Where(e => e.Header.ToLower().Trim().Contains(searchBar.Text.ToLower().Trim()));
            }
        }

        public void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender == searchBar)
            {
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    //PokemonList.ItemsSource = reset;
                }
                else
                {
                    //Update with search
                    Logger.Info(args.NewTextValue);
                    //itemListView.ItemsSource = Emails.Where(e => e.Header.ToLower().Trim().Contains(args.NewTextValue.ToLower().Trim()));
                }

            }
        }
    }

}
