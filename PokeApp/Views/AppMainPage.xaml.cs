using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PokeApp
{

    public partial class AppMainPage : ContentPage
    {

        //HttpClient client = new HttpClient();

        public AppMainPage()
        {
            InitializeComponent();
            //fetchDataz();
        }

        //private async void fetchDataz()
        //{
        //    const string url = "https://pokeapi.co/api/v2/pokemon/3/";

        //    var uri = new Uri(url);
        //    System.Diagnostics.Debug.WriteLine($"querying={uri}");
        //    var response = await client.GetAsync(uri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        System.Diagnostics.Debug.WriteLine($"content={content}");
        //        PokemonItem = JsonConvert.DeserializeObject<PokemonModel>(content);
        //        BindingContext = new PokemonViewModel(PokemonItem);
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine($"response={response}");
        //    }
        //}
    }
}
