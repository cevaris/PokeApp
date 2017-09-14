using System;
namespace PokeApp
{
    public class MainPageViewModel
    {
        public static MainPageViewModel Preview = new MainPageViewModel()
        {
            PokedexUrl = "PokeApp.Resources.dex1.png",
            AboutUrl = "PokeApp.Resources.jenny2.png"
        };

        public string PokedexUrl { get; set; }
        public string AboutUrl { get; set; }
    }
}
