using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PokeApp.iOS;
using Google.MobileAds;
using UIKit;
using PokeApp;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.iOS
{
    public class AdmobBanner : ViewRenderer<AdmobBannerView, BannerView>
    {
        BannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobBannerView> e)
        {
            base.OnElementChanged(e);

            var adMobElement = Element as AdmobBannerView;

            if (null != adMobElement)
            {

                adView = new BannerView(size: AdSizeCons.Banner)
                {
                    AdUnitID = Secrets.BannderId,
                    RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
                };

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen)
                        AddSubview(adView);
                    viewOnScreen = true;
                };

                Request request = Request.GetDefaultRequest();
                request.TestDevices = new string[]
                {
                    Request.SimulatorId
                };
                adView.LoadRequest(request);
                SetNativeControl(adView);
            }
        }
    }
}

