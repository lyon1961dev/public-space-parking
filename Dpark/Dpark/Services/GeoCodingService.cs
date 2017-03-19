
using System;
using Dpark.Services;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Dependency(typeof(GeoCodingService))]

namespace Dpark.Services
{
    public class GeoCodingService : IGeoCodingService
    {
        readonly Geocoder _GeoCoder;

        public GeoCodingService()
        {
            _GeoCoder = new Geocoder();
        }

        #region IGeoCodingService implementation

        public Position NullPosition
        {
            get { return new Position(0, 0); }
        }

        public async Task<Position> GeoCodeAddress(string addressString)
        {
            Position p = NullPosition;

            try
            {
                p = (await _GeoCoder.GetPositionsForAddressAsync(addressString)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return p;
        }

        #endregion
    }
}
