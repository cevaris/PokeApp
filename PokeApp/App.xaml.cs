using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PokeApp
{
    public class Constants
    {
        public static readonly string DatabaseName = "PokeApp.db3";
        public static readonly List<PokemonModel> TestData = new List<PokemonModel>{
            new PokemonModel {
                    Name="charmander",
                    Id=4,
                    URI = "https://pokeapi.co/api/v2/pokemon/4/"
            },
            new PokemonModel {
                Name="charmelean",
                Id=5,
                URI = "https://pokeapi.co/api/v2/pokemon/5/"
            }
        };

    }

    public partial class App : Application
    {
        private static PokeAppDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AppMainPage());
        }

        public static PokeAppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    ISQLite factory = DependencyService.Get<ISQLite>();
                    database = new PokeAppDatabase(factory);
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
