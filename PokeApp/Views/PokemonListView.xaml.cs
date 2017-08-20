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
            BindingContext = new PokemonListViewModel();
        }
    }
}
