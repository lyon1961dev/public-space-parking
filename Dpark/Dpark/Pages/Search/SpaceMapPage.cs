using Dpark.ViewModels.Search;
using Dpark.Pages.Base;
using Dpark.Localization;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;

namespace Dpark.Pages.Search
{
    public class SpaceMapPage : ModelBoundContentPage<SearchSpaceDetailViewModel>
    {
        Map _Map;
        public SpaceMapPage()
        {
            _Map = new Map()
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            //insert EXternal Map here;
            ToolbarItems.Add(
                new ToolbarItem(
                    TextResources.Get_Directions,
                    null,
                    async () =>
                    {
                        if (await DisplayAlert(
                                TextResources.Leave_Application,
                                TextResources.Leave_MappingDirections,
                                TextResources.Leave_Mapping_Yes,
                                TextResources.Cancel))
                        {

                            var pin = await ViewModel.LoadPin();

                            await CrossExternalMaps.Current.NavigateTo(pin.Label, pin.Position.Latitude, pin.Position.Longitude, NavigationType.Driving);

                            await ViewModel.PopAsync();
                        }
                    }
                )
            );
        }
        public async Task MakeMap()
        {
            Task<Pin> getPinTask = ViewModel.LoadPin();

            Pin pin = await getPinTask;

            _Map.Pins.Clear();

            _Map.Pins.Add(pin);

            await Task.Delay(App.AnimationSpeed);
            _Map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(5)));

            RelativeLayout relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(
                view: _Map,
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height)
            );

            Content = relativeLayout;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await this.MakeMap();
        }
    }
}
