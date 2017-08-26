using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Models;
using PokeApp.Utils;

namespace PokeApp
{

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
                    IShared factory = DependencyService.Get<IShared>();
                    System.Diagnostics.Debug.WriteLine(factory.GetDatabasePath());
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
