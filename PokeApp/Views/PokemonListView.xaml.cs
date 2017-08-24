using PokeApp.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PokeApp
{
    public partial class PokemonListView : StackLayout
    {
        public PokemonListView()
        {
            InitializeComponent();
            BindingContext = new PokemonIndexListViewModel();
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            //PokemonModel pokemon = (PokemonModel)e.SelectedItem;
            PokemonModel pokemon = Data.Constants.TestPokemonModel1;
            if (pokemon != null)
            {
                PokemonDetailPage page = new PokemonDetailPage();
                page.BindingContext = new PokemonDetailViewModel(pokemon);
                await Navigation.PushAsync(page);
            }
        }
    }

}
