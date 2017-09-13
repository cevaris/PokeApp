using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PokeApp.Droid;
using Android.Gms.Ads;
using PokeApp;
using Android.Widget;


[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.Droid
{
    public class AdmobBanner : ViewRenderer<AdmobBannerView, AdView>
    {
        AdView adView;
        AdView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;
            
            adView = new AdView(Forms.Context);
            adView.AdSize = AdSize.Banner;
            adView.AdUnitId = Secrets.BannerId;

            adView.LoadAd(new AdRequest.Builder().AddTestDevice(Secrets.DroidTestRequestId).Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobBannerView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}
