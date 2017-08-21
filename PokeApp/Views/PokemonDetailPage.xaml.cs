using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PokeApp
{
    public partial class PokemonDetailPage : ContentPage
    {
        public PokemonDetailPage()
        {
            InitializeComponent();

            // preview data
            PokemonModel pokemon = new PokemonModel
            {
                Name = "charmander",
                Id = 4
            };
            BindingContext = new PokemonDetailViewModel(pokemon);
        }
    }
}
