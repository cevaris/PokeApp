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

    public class PokemonViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        string name;
        string id;

        public PokemonViewModel() { }
        public PokemonViewModel(PokemonModel m)
        {
            this.Name = m.Name;
            this.Id = $"#{m.Id}";
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
            const string url = "https://pokeapi.co/api/v2/pokemon/2/";

            var uri = new Uri(url);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine($"querying={uri}");
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
