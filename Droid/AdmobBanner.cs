using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PokeApp.Droid;
using Android.Gms.Ads;
using PokeApp;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.Droid
{
    public class AdmobBanner : ViewRenderer<AdmobBannerView, AdView>
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<AdView> e)
        //{
        //    base.OnElementChanged(e);

        //    //convert the element to the control we want
        //    var adMobElement = Element as AdmobBannerView;

        //    if ((adMobElement != null) && (e.OldElement == null))
        //    {
        //        var ad = new AdView(Context);
        //        ad.AdSize = AdSize.Banner;
        //        ad.AdUnitId = Secrets.BannderId;
        //        var requestbuilder = new AdRequest.Builder();
        //        ad.LoadAd(requestbuilder.Build());
        //        SetNativeControl(ad);
        //    }
        //}
    }
}

