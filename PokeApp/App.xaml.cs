﻿using System.Collections.Generic;
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
