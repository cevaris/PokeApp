using Xamarin.Forms;
using System;
using PokeApp.Utils;
using PokeApp.Data;

namespace PokeApp
{
    public partial class MainPage : ContentPage
    {
        private ILogger logger = new ConsoleLogger(nameof(MainPage));

        public bool IsPushing { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            AboutImage.Source = ImageSource.FromResource("PokeApp.Resources.jenny2.png");
            PokedexImage.Source = ImageSource.FromResource("PokeApp.Resources.dex1.png");
        }

        async void OnTapped(object sender, EventArgs e)
        {
            if (IsPushing)
            {
                logger.Info("already pushing");
                return;
            } else {
                IsPushing = true;
            }
            
            if (sender == PokedexFrame)
            {
                logger.Info("clicked pokedex");
                PokedexListPage page = new PokedexListPage();
                page.BindingContext = new PokedexListPageModel();
                await Navigation.PushAsync(page);
                MessagingCenter.Send<MainPage>(this, PokedexStorage.MessageReady);
                IsPushing = false;
            }

            if (sender == AboutFrame)
            {
                logger.Info("clicked about");
                AboutPage page = new AboutPage();
                await Navigation.PushAsync(page);
                IsPushing = false;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                AboutStack.Orientation = StackOrientation.Horizontal;
                PokedexStack.Orientation = StackOrientation.Horizontal;
                logger.Info("setting orientation to horizontal");
            }
            else
            {
                AboutStack.Orientation = StackOrientation.Vertical;
                PokedexStack.Orientation = StackOrientation.Vertical;
                logger.Info("setting orientation to vertical");
            }
        }
    }
}
