using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Data.Tables;
using System;

namespace PokeApp
{
    public partial class AppMainPage : ContentPage
    {
        private PokemonResourceListViewModel viewModel = new PokemonResourceListViewModel();

        public AppMainPage()
        {
            InitializeComponent();
            PokemonList.BindingContext = viewModel;
        }

        public void Update()
        {
            viewModel.Update();
        }
    }
}
