using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ImageCircle.Forms.Plugin.Droid;
using Syncfusion.SfChart.XForms.Droid;
using Dpark;

namespace Dpark.Droid
{
    [Activity(Label = "Dpark", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);

            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabbar;
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;

            Forms.Init(this, bundle);

            FormsMaps.Init(this, bundle);

            new SfChartRenderer();
            ImageCircleRenderer.Init();

            LoadApplication(new App());
        }
    }
}

