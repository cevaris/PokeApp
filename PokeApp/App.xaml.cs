using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Models;

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
