using System;
namespace PokeApp
{
    public class MainPageViewModel
    {
        public static MainPageViewModel Preview = new MainPageViewModel()
        {
            PokedexUrl = "https://s3-us-west-2.amazonaws.com/pokeapp.assets/app/images/dex2.png",
            AboutUrl = "https://s3-us-west-2.amazonaws.com/pokeapp.assets/app/images/jenny.png"
        };

        public string PokedexUrl { get; set; }
        public string AboutUrl { get; set; }
    }
}
