
using Xamarin.Forms;
using Dpark.Pages.Base;
using Dpark.ViewModels.About;

namespace Dpark.Pages.About
{
    public partial class AboutPage : AboutPageXaml
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
    public class AboutPageXaml : ModelBoundContentPage<AboutViewModel> { }
}
