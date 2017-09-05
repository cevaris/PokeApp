using System;
namespace PokeApp
{
    public class MainPageViewModel
    {
        public static MainPageViewModel Preview = new MainPageViewModel()
        {
            PokedexUrl = "http://icons.iconarchive.com/icons/thiago-silva/palm/256/Photos-icon.png",
            AboutUrl = "https://s3-us-west-2.amazonaws.com/pokeapp.assets/app/images/jenny.png"
        };

        public string PokedexUrl { get; set; }
        public string AboutUrl { get; set; }
    }
}
