using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PokeApp.iOS;
using Google.MobileAds;
using UIKit;
using PokeApp;
using CoreGraphics;
using PokeApp.Utils;

[assembly: ExportRenderer(typeof(AdmobBannerView), typeof(AdmobBanner))]
namespace PokeApp.iOS
{
    public class AdmobBanner: ViewRenderer
    {
        BannerView adView;
        bool viewOnScreen = false;
        private readonly static ILogger logger = new ConsoleLogger(nameof(AdmobBanner));

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {
                UIViewController viewCtrl = null;

                foreach (UIWindow v in UIApplication.SharedApplication.Windows)
                {
                    if (v.RootViewController != null)
                    {
                        viewCtrl = v.RootViewController;
                    }
                }

                logger.Info($"found root controller {viewCtrl.NibName}");
                adView = new BannerView(
                    size: AdSizeCons.SmartBannerPortrait,
                    origin: new CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height)
                )
                {
                    AdUnitID = Secrets.BannerId,
                    RootViewController = viewCtrl
                };

                adView.ReceiveAdFailed += (sender, args) =>
                {
                    var error = ((BannerViewErrorEventArgs)args).Error;
                    logger.Error($"received failed ad: {error} {error.Code}");
                };

                adView.WillChangeAdSizeTo += (sender, args) =>
                {
                    logger.Info($"changing add size to: {((AdSizeDelegateSizeEventArgs)args).Size}");
                };

                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen)
                    {
                        logger.Info($"received ad: {args}");
                        AddSubview(adView);
                    }
                    viewOnScreen = true;
                };

                Request request = Request.GetDefaultRequest();
                //request.TestDevices = new string[] { Secrets.TestRequestId };
                //request.TestDevices = new[] { Request.SimulatorId, Secrets.TestRequestId };
                adView.LoadRequest(request);
                SetNativeControl(adView);
            }
        }
    }
}

