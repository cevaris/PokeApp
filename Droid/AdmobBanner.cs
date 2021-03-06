﻿using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PokeApp.Droid;
using Android.Gms.Ads;
using PokeApp;
using Android.Widget;
using PokeApp.Utils;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.Droid
{
    public class AdmobBanner : ViewRenderer<AdmobBannerView, AdView>
    {
        AdView adView;

        private ILogger logger = new ConsoleLogger(nameof(AdmobBanner));

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobBannerView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {

                ScreenLayout screenlayout = Resources.Configuration.ScreenLayout;

                logger.Info($"screenLayout {screenlayout}");

                adView = new AdView(Forms.Context);

                adView.AdUnitId = Secrets.DroidBannerId;
                if (App.IsDebug)
                {
                    adView.AdUnitId = Secrets.TestBannerId;
                }

                adView.AdSize = AdSize.Banner;

                var adBuilder = new AdRequest.Builder();
                if(App.IsDebug) {
                    adBuilder.AddTestDevice(Secrets.DroidTestRequestId);
                }  

                adView.LoadAd(adBuilder.Build());
                SetNativeControl(adView);
            }
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}
