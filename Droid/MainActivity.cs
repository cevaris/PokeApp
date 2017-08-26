using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;

namespace PokeApp.Droid
{
    [Activity(Label = "PokeApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AssetManager assets = this.Assets;
            string content;
            using (StreamReader sr = new StreamReader(assets.Open("Pokedex.zip")))
            {
                content = sr.ReadToEnd();
            }
            System.Diagnostics.Debug.WriteLine(content.Length);

            LoadApplication(new App());
        }
    }
}
