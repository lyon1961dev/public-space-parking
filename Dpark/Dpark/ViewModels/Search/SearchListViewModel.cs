using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dpark.Statics;
using Dpark.ViewModels.Base;
using Dpark.Models;
using Xamarin.Forms;

using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System;

namespace Dpark.ViewModels.Search
{
    public class SearchListViewModel : BaseViewModel
    {
        ObservableCollection<PublicSpace> _PublicSpaces;
        public ObservableCollection<PublicSpace> PublicSpaces
        {
            get
            {
                return _PublicSpaces;
            }
            set
            {
                _PublicSpaces = value;
                OnPropertyChanged("PublicSpaces");
            }
        }

        public string location;
        public string street_add;
        public string city_add;
        public string country_add;
        public string zip_add;
        double latitude = 0.0;
        double longitude = 0.0;

        public string Filter;
        public SearchListViewModel(string filter)
        {
            PublicSpaces = new ObservableCollection<PublicSpace>();
            IsInitialized = false;

            Filter = filter;
        }

        public async Task <bool> LoadSpaceData()
        {
            bool success = false;
            Debug.WriteLine(PublicSpaces.Count + " IsInitialized: " + IsInitialized);
            IsBusy = true;

            try
            {
                var client = new HttpClient();
                var json = await client.GetAsync("https://dpark.us/allspaces.json");
                //var json = await client.GetAsync("http://lyon.us.com/allspaces.json");

                json.EnsureSuccessStatusCode();


                var results = await json.Content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<RootObject>(results);
                List<Post> posts = rootObject.posts;

                foreach (var post in posts)
                {
                    street_add = city_add = country_add = zip_add = null;

                    List<Metadata> metas = post.metadata;
                    foreach (var meta in metas)
                    {

                        if (meta.key.Contains("street_address") && meta.value.ToString() != null)
                            street_add = meta.value.ToString();

                        else if (meta.key.Contains("geo_address") && meta.value.ToString() != null)
                            street_add = meta.value.ToString();

                        if (meta.key.Contains("city") && meta.value.ToString() != null)
                            city_add = meta.value.ToString();

                        if (meta.key.Contains("country") && meta.value.ToString() != null)
                            country_add = meta.value.ToString();

                        if (meta.key.Contains("zip") && meta.value.ToString() != null)
                            zip_add = meta.value.ToString();

                        if (meta.key.Contains("geo_latitude") && meta.value.ToString() != "")
                            latitude = Convert.ToDouble(meta.value.ToString());

                        else if(meta.key.Contains("lat") && meta.value.ToString() != "")
                            latitude = Convert.ToDouble(meta.value.ToString());

                        if (meta.key.Contains("geo_longitude") && meta.value.ToString() != "")
                            longitude = Convert.ToDouble(meta.value.ToString());

                        else if (meta.key.Contains("lon") && meta.value.ToString() != "")
                            longitude = Convert.ToDouble(meta.value.ToString());

                        location = country_add + " " + zip_add;

                    }


                    PublicSpaces.Add(new PublicSpace
                    {
                        Title = post.title,
                        URL = post.URL,
                        ImageSource = "https://dpark.us" + post.featured_image,
                        Address = street_add,
                        City = city_add,
                        Country = location,

                        Lat = latitude,
                        Long = longitude,

                    });

                
                    Debug.WriteLine("" + post.URL);

                }

                IsBusy = false;
                IsInitialized = true;
                success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return success;
        }
      
        public async Task FilterSpaceData()
        {
            IsBusy = true;
          
            if (string.IsNullOrWhiteSpace(Filter))
            {
                PublicSpaces = _PublicSpaces;
            }
            else
            {
                PublicSpaces = new ObservableCollection<PublicSpace>(PublicSpaces.Where((PublicSpaces) =>
                           PublicSpaces.Title.ToLower().Contains(Filter.ToLower())));
               
                IsBusy = false;
            }
            await Task.Delay(App.AnimationSpeed);
        }
    }
}
