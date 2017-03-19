using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Dpark.Pages.Base;
using Dpark.ViewModels.Search;
using Dpark.Pages.Submit;
using static Dpark.Statics.FontSizes;

namespace Dpark.Pages.Search
{
    public class SearchPage : ContentPage
    {
        Map _Map;
        SearchBar _Searchbar;
        StackLayout stacklayout;
        StackLayout searchbarstack;
        
        public SearchPage()
        {
           // BindingContext = _SearchViewModel = new SearchViewModel();
            stacklayout = new StackLayout { Spacing = 0 };
            searchbarstack = new StackLayout { Opacity = 0.8, Padding = new Thickness(0,0,0,0)};

            _Map = new Map()
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            _Searchbar = new SearchBar()
            {
                Placeholder = "Search for place or address",
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = _120PercentOfSmall
            };

            _Searchbar.TextChanged += (sender, e) => {
                /*Work to be done at time text change*/
            };
            _Searchbar.SearchButtonPressed += async (sender, e) => {
                /*Work to be done at time of Search button click*/
                //var viewModel = new SearchListViewModel(_Searchbar.Text);
                //await viewModel.FilterSpaceData();
                await PushSearchListPage();
            };

            _Searchbar.Focus();
            searchbarstack.Children.Add(_Searchbar);
            stacklayout.Children.Add(searchbarstack);
            stacklayout.Children.Add(_Map);

            ToolbarItems.Add(new ToolbarItem("Add", "add_ios_gray", async () =>
                   await PushWebSubmitPage()));
            //_SalesDashboardLeadsViewModel.PushTabbedLeadPageCommand.Execute(null)));

            Content = stacklayout;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //_Searchbar.Focus();
            if (await MakeMap())
                return;

            await MakeMap();
            await Task.Delay(App.AnimationSpeed);
        }

        
        public async Task <bool> MakeMap()
        {
            bool success = false;
            await Task.Delay(App.AnimationSpeed);
            //Honolulu initial position
            _Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(21.300, -157.8167), Distance.FromMiles(5)));
            success = true;
            return success;

        }
        async Task PushWebSubmitPage()
        {
            var webSubmitPage = new WebSubmitPage()
            {
                Title = "Submit Space",
            };

            await Navigation.PushAsync(webSubmitPage);
        }
        async Task PushSearchListPage()
        {
            SearchListViewModel viewModel = new SearchListViewModel(_Searchbar.Text);
            var page = new SearchResultsPage()
            {
                BindingContext = viewModel,
                Title = "Search Results",               
                };

            await Navigation.PushAsync(page);
        }
    }
}
