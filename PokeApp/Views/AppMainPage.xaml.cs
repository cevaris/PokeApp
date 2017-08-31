using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Data.Tables;
using System;

namespace PokeApp
{
    public partial class AppMainPage : ContentPage
    {
        private PokemonListViewModel viewModel = new PokemonListViewModel();

        public AppMainPage()
        {
            InitializeComponent();
            PokemonList.BindingContext = viewModel;
        }
    }
}
