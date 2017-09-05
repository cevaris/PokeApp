using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Data.Tables;
using System;

namespace PokeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = MainPageViewModel.Preview;
            InitializeComponent();

            PokedexImage.Source = ImageSource.FromUri(new Uri(MainPageViewModel.Preview.PokedexUrl));

        }
    }
}
