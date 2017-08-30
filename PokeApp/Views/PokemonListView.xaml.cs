using PokeApp.Data.Models;
using PokeApp.Data.Mappers;
using PokeApp.Data.Tables;
using Xamarin.Forms;


namespace PokeApp
{
    public partial class PokemonListView : StackLayout
    {
        public PokemonListView()
        {
            InitializeComponent();
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            PokemonSpeciesTable selectedPokemon = (PokemonSpeciesTable)e.SelectedItem;
            if (selectedPokemon != null)
            {
                PokemonDetailPage page = new PokemonDetailPage();
                PokemonModel pokemon = await PokemonMapper.GetById(selectedPokemon.Id);
                page.BindingContext = new PokemonDetailViewModel()
                {
                    Pokemon = pokemon
                };
                await Navigation.PushAsync(page);
            }
        }
    }

}
