using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Dpark.ViewModels.Base;
using Dpark.Localization;

namespace Dpark.ViewModels.Splash
{
    public class SplashViewModel : BaseViewModel
    {


        public SplashViewModel(INavigation navigation = null)
            : base(navigation)
        {

        }

        bool _IsLoadingUI;
        public bool IsLoadingUI
        {
            get
            {
                return _IsLoadingUI;
            }
            set
            {
                _IsLoadingUI = value;
                OnPropertyChanged("IsLoadingUI");
            }
        }

        bool _isRetry;
        public bool IsRetry
        {
            get
            {
                return _isRetry;
            }
            set
            {
                _isRetry = value;
                BtnRetryText = TextResources.btnTxtRerty;
                OnPropertyChanged("");
            }
        }

        private string _btnRetryText = "";
        public string BtnRetryText
        {
            get
            {
                return _btnRetryText;
            }
            set
            {
                _btnRetryText = value;
                OnPropertyChanged("");
            }
        }
        private string _processMessage;

        public string ProcessMessage
        {
            get
            {
                return _processMessage;
            }
            set
            {
                _processMessage = value;
                OnPropertyChanged("IsProcessMessage");
            }
        }
        public void IsProcessMessage(string message)
        {
            ProcessMessage = message;
        }
    }
}
