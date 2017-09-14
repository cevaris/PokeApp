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

            if (sender == PokeballLogoLink)
            {
                Device.OpenUri(new Uri("https://pixabay.com/en/users/Alanyadk-1919646/"));
            }

            if (sender == SupportLink)
            {
                Device.OpenUri(new Uri("https://github.com/cevaris/PokeApp-Support/issues?q=is%3Aissue"));
            }
        }
    }
}
