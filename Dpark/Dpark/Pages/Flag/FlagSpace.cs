using Xamarin.Forms;

namespace Dpark.Pages.Flag
{
    public class FlagSpace : ContentPage
    {
        WebView webView;
        public FlagSpace()
        {
            var layout = new StackLayout();
            webView = new WebView() { HeightRequest = 1000, WidthRequest = 1000, Source = "https://dpark.us/flag" };
            layout.Children.Add(webView);
            Content = layout;
        }
    }
}
