
using System;
using Foundation;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Dpark.Statics;
using ImageCircle.Forms.Plugin.iOS;

namespace Dpark.iOS
{

    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            new SfChartRenderer();

            Forms.Init();
            Xamarin.FormsMaps.Init();

            ImageCircleRenderer.Init();

            LoadApplication(new App());

            ConfigureApplicationTheming();
            return base.FinishedLaunching(app, options);
        }

        void ConfigureApplicationTheming()
        {
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = Palette._001.ToUIColor();
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes { ForegroundColor = UIColor.White };
            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);

            UITabBar.Appearance.TintColor = UIColor.White;
            UITabBar.Appearance.BarTintColor = UIColor.White;
            UITabBar.Appearance.SelectedImageTintColor = Palette._003.ToUIColor();
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = Palette._003.ToUIColor() }, UIControlState.Selected);

            UIProgressView.Appearance.ProgressTintColor = Palette._003.ToUIColor();
        }
    }
}
