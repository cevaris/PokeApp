using System.Collections.Generic;
using Xamarin.Forms;
using PokeApp.Data.Tables;
using System;

namespace PokeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
