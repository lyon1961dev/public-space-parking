
using System;
using Dpark.Localization;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Dpark.Pages;
using Dpark.Pages.Splash;
using Dpark.ViewModels.Splash;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Dpark
{
    public partial class App : Application
    {
        static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }
        public App()
        {
            InitializeComponent();
            app = this;

            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            GoToRoot();
            //MainPage = new SplashPage();
        }

        #region OnStart
        protected override void OnStart()
        {
            OnStarting(EventArgs.Empty);
        }

        public event EventHandler Starting;

        protected virtual void OnStarting(EventArgs e)
        {
            if (Starting != null) Starting(this, e);
        }
        #endregion

        #region OnSleep
        protected override void OnSleep()
        {
            OnSuspending(EventArgs.Empty);
        }

        public event EventHandler Suspending;

        protected virtual void OnSuspending(EventArgs e)
        {
            if (Suspending != null) Suspending(this, e);
        }
        #endregion

        #region OnResume
        protected override void OnResume()
        {
            OnResuming(EventArgs.Empty);
        }

        public event EventHandler Resuming;

        private void OnResuming(EventArgs e)
        {
            if (Resuming != null) Resuming(this, e);
        }
        #endregion
        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                CurrentApp.MainPage = new RootTabPage();
            }
            else
            {
                //CurrentApp.MainPage = new RootPage();
                CurrentApp.MainPage = new Pages.MapPage();
            }
        }

        public static async Task ExecuteIfConnected(Func<Task> actionToExecuteIfConnected)
        {
            //bool success = false;
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
                //success = true;
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }

            //return success;
        }

        public static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                TextResources.NetworkConnection_Alert_Title,
                TextResources.NetworkConnection_Alert_Message,
                TextResources.NetworkConnection_Alert_Confirm,
                "Retry");
        }

        public static bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }
        public static int AnimationSpeed = 250;
    }
}
