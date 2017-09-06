using System;
using System.Collections.Generic;
using PokeApp.Utils;
using Xamarin.Forms;

namespace PokeApp
{
    public partial class AboutPage : ContentPage
    {
        private ILogger logger = new ConsoleLogger(nameof(AboutPage));

        public AboutPage()
        {
            InitializeComponent(); 
            NavigationPage.SetHasNavigationBar(this, true);
        }

        void OnTapped(object sender, EventArgs e)
        {
            if (sender == PokemonLink)
            {
                Device.OpenUri(new Uri("https://www.pokemon.com/"));
            }

            if (sender == PokemonImagesLink)
            {
                Device.OpenUri(new Uri("https://pokemondb.net/"));
            }

            if (sender == PokemonDatabaseLink)
            {
                Device.OpenUri(new Uri("https://github.com/veekun/pokedex"));
            }

            if (sender == JennyImageLink)
            {
                Device.OpenUri(new Uri("https://animemissy123.deviantart.com/"));
            }
        }
    }
}
