using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Dpark.Models;
using Dpark.ViewModels.Base;
using Dpark.Pages.Search;
using Dpark.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Dpark.ViewModels.Search
{
   
    public class SearchSpaceDetailViewModel:BaseViewModel
    {
        readonly IGeoCodingService _GeoCodingService;
        public PublicSpace PublicSpace { get; set; }
        readonly Page _CurrentPage;
        public Page CurrentPage
        {
            get { return _CurrentPage; }
        }

        public SearchSpaceDetailViewModel(PublicSpace publicspace, Page currentPage)
        {
            PublicSpace = publicspace;
            this.Title = publicspace.Title;

            _CurrentPage = currentPage;
            _GeoCodingService = DependencyService.Get<IGeoCodingService>();
        }

        ICommand _MapMarkerIconTappedCommand;

        public ICommand MapMarkerIconTappedCommand
        {
            get
            {
                return _MapMarkerIconTappedCommand ??
                    (_MapMarkerIconTappedCommand = new Command(async () => await ExecuteMapMarkerIconTappedCommand()));
            }
        }

        async Task ExecuteMapMarkerIconTappedCommand()
        {
            await PushAsync(new SpaceMapPage()
            {
                Title = PublicSpace.Title,
                BindingContext = this
            });
        }


        public async Task GoBack()
        {
            await Navigation.PopAsync();
        }

        public async Task<Pin> LoadPin()
        {
            Position p = _GeoCodingService.NullPosition;
            await Task.Delay(App.AnimationSpeed);
            var address = PublicSpace.Address;

            //Lookup Lat/Long all the time unless an account where the address is read-only
            //TODO: Only look up if no value, or if address properties have changed.
            //if (Contact.Latitude == 0)
            //if (PublicSpace.Lat = null)
            //{
            //    p = await _GeoCodingService.GeoCodeAddress(address);

            //    Account.Latitude = p.Latitude;
            //    Account.Longitude = p.Longitude;
            //}
            //else
            //{
            //    p = new Position(Account.Latitude, Account.Longitude);
            //}

            p = new Position(PublicSpace.Lat, PublicSpace.Long);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = p,
                Label = PublicSpace.Title,
                Address = address
            };

            return pin;
        }

        public async Task LoadUrl()
        {
           
            var url = PublicSpace.URL;

            //return url;
            await Task.Delay(App.AnimationSpeed);
        }

    }
}
