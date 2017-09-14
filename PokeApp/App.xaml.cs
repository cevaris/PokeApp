using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Data.Models;
using PokeApp;
using PokeApp.Utils;
using PokeApp.Data;
using PokeApp.Data.Tables;
using System.Threading.Tasks;
using System;
using FFImageLoading;

namespace PokeApp
{

    public partial class App : Application
    {

        public static bool IsDebug
        {
            get
            {
                bool isDebug;
#if DEBUG
                isDebug = true;
#else
                isDebug = false;
#endif
                return isDebug;
            }
        }

        private static IShared shared;
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

        public App()
        {
            InitializeComponent();

            MainPage main = new MainPage();
            main.BindingContext = MainPageViewModel.Preview;

            NavigationPage page = new NavigationPage(main);
            MainPage = page;

            if (App.IsDebug)
            {
                //Kill cache in dev
                ImageService.Instance.InvalidateCacheAsync(FFImageLoading.Cache.CacheType.All).Wait();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            PokedexStorage.Init();
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
