using PokeApp.Data.Models;
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
            BindingContext = new PokemonResourceListViewModel();
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            // Check cache for resource
            // Fetch named resource
            // Parse resource
            // Push Model to be rendered

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
