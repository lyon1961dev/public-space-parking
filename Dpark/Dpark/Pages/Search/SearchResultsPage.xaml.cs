using Dpark.Pages.Base;
using Dpark.ViewModels.Search;
using Dpark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dpark.Pages.Search
{
    public partial class SearchResultsPage : SearchResultsPageXaml
    {
        public SearchResultsPage()
        {
            InitializeComponent();

            //ToolbarItems.Add(new ToolbarItem("Add", "add_ios_gray", async () =>
            //       await OnSearchClicked()));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.IsInitialized)
            {
                return;
            }

            await ViewModel.LoadSpaceData();
            await ViewModel.FilterSpaceData();


            Title = "Found (" + ViewModel.PublicSpaces.Count + ") item(s)";
            ViewModel.IsInitialized = true;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            PublicSpace publicspace = (PublicSpace)e.Item;
            await PushTabbedPage(publicspace);
        }
       
        async Task PushTabbedPage(PublicSpace publicspace = null)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                var searchSpaceDetailPage = new SearchSpaceDetailPage()
                {
                    BindingContext = new SearchSpaceDetailViewModel(publicspace, this) { Navigation = this.Navigation},
                };
                await Navigation.PushAsync(searchSpaceDetailPage);
            }
        }
    }

    public abstract class SearchResultsPageXaml : ModelBoundContentPage<SearchListViewModel> { }
}
