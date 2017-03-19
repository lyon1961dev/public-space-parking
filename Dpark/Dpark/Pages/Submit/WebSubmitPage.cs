using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Dpark.Pages.Submit
{
    public class WebSubmitPage : ContentPage
    {
        WebView webView;
        public WebSubmitPage()
        {
            var layout = new StackLayout();
            webView = new WebView() { HeightRequest = 1000, WidthRequest = 1000, Source = "https://dpark.us/add" };
            layout.Children.Add(webView);
            Content = layout;
        }
    }
}
