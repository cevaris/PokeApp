using System;
namespace PokeApp
{
    public class MainPageViewModel
    {
        public static MainPageViewModel Preview = new MainPageViewModel()
        {
            PokedexUrl = "https://s3-us-west-2.amazonaws.com/pokeapp.assets/app/images/dex1.png",
            AboutUrl = "https://s3-us-west-2.amazonaws.com/pokeapp.assets/app/images/jenny2.png"
        };

        public string PokedexUrl { get; set; }
        public string AboutUrl { get; set; }
    }
}
