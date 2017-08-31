using PokeApp.Data.Models;
using PokeApp.Data.Mappers;
using PokeApp.Data.Tables;
using Xamarin.Forms;
using PokeApp.Utils;

namespace PokeApp
{
    public partial class PokemonListView : StackLayout
    {
        private ILogger Logger = new ConsoleLogger(nameof(PokemonListViewModel));

        public PokemonListView()
        {
            InitializeComponent();
            PokemonList = new ListView(ListViewCachingStrategy.RecycleElement);
        }

        void Handle_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            Logger.Info($"fired {e.Item.ToString()}");
            MessagingCenter.Send<PokemonListView, ItemVisibilityEventArgs>(this, "PokemonListViewModel.Page", e);
        }

        async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            PokemonBasicModel selectedPokemon = (PokemonBasicModel)e.SelectedItem;
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
