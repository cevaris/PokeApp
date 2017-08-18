using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PokeApp
{

    public class Pokemon
    {
        public Pokemon() { }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public partial class AppMainPage : ContentPage
    {

        HttpClient client;
        Pokemon PokemonItem;

        public AppMainPage()
        {
            InitializeComponent();

            PokemonItem = new Pokemon();
            client = new HttpClient();
            fetchDataz();
        }

        private async void fetchDataz()
        {
            //client.DefaultRequestHeaders.Add("Content-Type","application/json");

            const string url = "https://pokeapi.co/api/v2/pokemon/2/";

            var uri = new Uri(url);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"content={content}");
                PokemonItem = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"response={response}");
            }

        }
    }
}
