using System;
using System.Threading.Tasks;
using System.Diagnostics;
using Dpark.ViewModels.Splash;
using Dpark.Pages.Base;
using Dpark.Localization;
using Dpark.ViewModels.Search;

namespace Dpark.Pages.Splash
{
    public partial class SplashPage : SplashPageXaml
    {
        SearchListViewModel viewModel;
        public SplashPage()
        {
            InitializeComponent();
            BindingContext = new SplashViewModel();
            viewModel = new SearchListViewModel("");
            this.txtProcessMessage.Text = "Wait...";
            this.txtProcessMessage.IsVisible = true;
        }

        async Task IsLoading()
        {
            //ViewModel.IsProcessMessage(TextResources.txtProcessConnection);
            this.txtProcessMessage.Text = TextResources.txtProcessConnection;

            await App.ExecuteIfConnected(async () =>
            {
                // trigger the activity indicator through the IsPresentingLoginUI property on the ViewModel
                ViewModel.IsLoadingUI = true;
                                  
                if (await LoadParkingSpaces())
                {
                    // Pop off the modally presented SplashPage.
                    // Note that we're not popping the ADAL auth UI here; that's done automatcially by the ADAL library when the Authenticate() method returns.
                    this.txtProcessMessage.Text = TextResources.txtProcessLoadingData;
                    await Task.Delay(App.AnimationSpeed);
                    App.GoToRoot();
                                       
                }
            });

            ViewModel.IsRetry = true;
            ViewModel.IsProcessMessage(TextResources.txtRertyCheckInternet);
            ViewModel.IsLoadingUI = false;
        }

        async Task<bool> LoadParkingSpaces()
        {
            bool success = false;
            try
            {
                //ViewModel.IsProcessMessage(TextResources.txtProcessLoadingData);
                success = true;// await viewModel.LoadSpaceData();
                await Task.Delay(3000);//for fun, i will del it
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                ViewModel.IsLoadingUI = false;
            }

            return success;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);

            await IsLoading();
        }
        

        public async void OnRetryClicked(object sender, EventArgs args)
        {
            ViewModel.IsRetry = false;
            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);

            ViewModel.IsProcessMessage("Loading...");
            ViewModel.IsLoadingUI = true;
            await IsLoading();
        }
       
    }

    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel> { }
}
