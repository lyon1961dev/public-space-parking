using Dpark.ViewModels.Search;
using Dpark.Pages.Base;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Dpark.Pages.Search
{
    public class SpaceFlagPage : ContentPage//ModelBoundContentPage<SearchSpaceDetailViewModel>
    {
        WebView webView;
        public SpaceFlagPage(string Url)
        {
            //Url = viewModel.PublicSpaces.U";
            var layout = new StackLayout();
            webView = new WebView() { HeightRequest = 1000, WidthRequest = 1000, Source = Url};
            layout.Children.Add(webView);
            Content = layout;
        }
    }
}
