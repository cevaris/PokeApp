using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Data.Models;
using PokeApp.Utils;
using PokeApp.Data;
using PokeApp.Data.Tables;
using System.Threading.Tasks;
using System;

namespace PokeApp
{

    public partial class App : Application
    {
        private static IShared shared;

        private AppMainPage appMainPage;

        public App()
        {
            InitializeComponent();
            appMainPage = new AppMainPage();
            MainPage = new NavigationPage(appMainPage);
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
            appMainPage.Update();

            //SQLite.SQLiteAsyncConnection conn = App.Shared.GetAsyncConnection();

            //var query = conn.Table<PokemonSpeciesTable>().ToListAsync();
            //MainPage.Navigation.PushAsync(new AppMainPage(query.Result)).GetAwaiter().GetResult();
            //MainPage = new NavigationPage(new AppMainPage(query.Result));

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
