using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PokeApp.Views;
using PokeApp.Droid;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.Droid
{
    public class AdmobBanner : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            //convert the element to the control we want
            var adMobElement = Element as AdmobBannerView;

            if ((adMobElement != null) && (e.OldElement == null))
            {
                var ad = new AdView(Context);
                ad.AdSize = AdSize.Banner;
                ad.AdUnitId = adMobElement.Id;
                var requestbuilder = new AdRequest.Builder();
                ad.LoadAd(requestbuilder.Build());
                SetNativeControl(ad);
            }
        }
    }
}

