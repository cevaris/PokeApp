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
using Xamarin.Forms;

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

            //AssetManager assets = this.Assets;
            //var fd = assets.Open("AboutAssets.txt");
            //System.Diagnostics.Debug.WriteLine($"fd len {fd.}");
            //fd.Close();

            //fd = assets.Open(PokeApp.Data.Constants.ZipName);
            //System.Diagnostics.Debug.WriteLine($"fd len {fd.Length}");
            //fd.Close();


            LoadApplication(new App());
        }
    }
}
