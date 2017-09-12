using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PokeApp.Views;
using PokeApp.iOS;
using Google.MobileAds;
using UIKit;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.iOS
{
    public class AdmobBanner : ViewRenderer
    {
        BannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            var adMobElement = Element as AdmobBannerView;

            if (null != adMobElement)
            {

                adView = new BannerView(size: AdSizeCons.Banner)
                {
                    AdUnitID = adMobElement.Id,
                    RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
                };

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen)
                        AddSubview(adView);
                    viewOnScreen = true;
                };

                adView.LoadRequest(Request.GetDefaultRequest());
                SetNativeControl(adView);
            }
        }
    }
}

