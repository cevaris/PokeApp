using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PokeApp
{

    public class PokemonModel
    {
        public PokemonModel() { }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class PokemonViewModel
    {
        public PokemonViewModel() { }
        public PokemonViewModel(PokemonModel m)
        {
            this.Name = m.Name;
            this.Id = $"#{m.Id}";
        }

        public string Name { get; set; }
        public string Id { get; set; }

    }


    public partial class AppMainPage : ContentPage
    {

        HttpClient client = new HttpClient();
        PokemonModel PokemonItem;


        public AppMainPage()
        {
            InitializeComponent();
            BindingContext = new PokemonViewModel
            {
                Name = "",
                Id = ""
            };

            fetchDataz();
        }

        private async void fetchDataz()
        {
            const string url = "https://pokeapi.co/api/v2/pokemon/3/";

            var uri = new Uri(url);
            System.Diagnostics.Debug.WriteLine($"querying={uri}");
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"content={content}");
                PokemonItem = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonModel>(content);
                BindingContext = new PokemonViewModel(PokemonItem);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"response={response}");
            }
        }
    }
}
