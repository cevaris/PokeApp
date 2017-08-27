using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Models;
using PokeApp.Utils;
using PokeApp.Data;

namespace PokeApp
{

    public partial class App : Application
    {
        private static IShared shared;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AppMainPage());
        }

        public static IShared Shared
        {
            get
            {
                if (shared == null)
                {
                    shared = DependencyService.Get<IShared>();
                }
                return shared;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            PokedexStorage.Init();

            //SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();
            //var query = conn.Table<PokemonSpeciesTable>().Take(5).ToListAsync();

            //var result = query.Result;

            //foreach (var species in result)
                //System.Diagnostics.Debug.WriteLine("Species: " + species.Identifier);
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
