using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.MobileAds;
using UIKit;

namespace PokeApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override bool WillFinishLaunching(UIApplication uiApplication, NSDictionary launchOptions) {
            MobileAds.Configure(Secrets.AppId);
            return base.WillFinishLaunching(uiApplication, launchOptions);
        }
    }
}
