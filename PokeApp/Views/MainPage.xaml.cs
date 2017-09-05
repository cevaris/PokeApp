using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Data.Tables;
using System;
using PokeApp.Utils;

namespace PokeApp
{
    public partial class MainPage : ContentPage
    {
        private ILogger logger = new ConsoleLogger(nameof(MainPage));

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = MainPageViewModel.Preview;
            InitializeComponent();

            //PokedexImage.Source = ImageSource.FromUri(new Uri(MainPageViewModel.Preview.PokedexUrl));
            //PokedexImage.Source = ImageSource.FromUri(new Uri("http://icons.iconarchive.com/icons/thiago-silva/palm/256/Photos-icon.png"));
            //PokedexImage.Source = new UriImageSource
            //{
            //    CachingEnabled = false,
            //    Uri = new Uri("http://icons.iconarchive.com/icons/thiago-silva/palm/256/Photos-icon.png")
            //};
        }

        async void OnTapped(object sender, EventArgs e)
        {
            if (sender == PokedexFrame)
            {
                logger.Info("clicked pokedex");
                PokemonListView page = new PokemonListView();
                page.BindingContext = new PokemonListViewModel();
                await Navigation.PushAsync(page);
            }

            if (sender == AboutFrame)
            {
                logger.Info("clicked about");
            }
        }
    }
}
