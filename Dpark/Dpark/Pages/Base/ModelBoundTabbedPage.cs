using Dpark.ViewModels.Base;
using Xamarin.Forms;

namespace Dpark.Pages.Base
{
    public abstract class ModelBoundTabbedPage<TViewModel> : TabbedPage where TViewModel : BaseViewModel
    {
        protected TViewModel ViewModel
        {
            get { return base.BindingContext as TViewModel; }
        }
        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }
    }
}
