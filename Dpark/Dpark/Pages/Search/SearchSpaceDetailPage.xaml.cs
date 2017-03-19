using Dpark.Pages.Base;
using Dpark.ViewModels.Search;
using Dpark.Models;
using Xamarin.Forms;
using System;

namespace Dpark.Pages.Search
{
    public partial class SearchSpaceDetailPage : SearchSpaceDetailPageXaml
    {
        public SearchSpaceDetailPage()
        {
            InitializeComponent();
        }

        async void FlagSpaceTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpaceFlagPage(ViewModel.PublicSpace.URL));
            //await Navigation.PushAsync(new SpaceFlagPage()
            //{
            //    BindingContext = new SearchSpaceDetailViewModel()
            //    {
            //        Navigation = this.Navigation
            //    },
            //    Icon = new FileImageSource()
            //    {
            //        File = "ProductsTab" // only used  on iOS
            //    }
            //});
        }
    }

    public abstract class SearchSpaceDetailPageXaml : ModelBoundContentPage<SearchSpaceDetailViewModel>
    {

    }
}
