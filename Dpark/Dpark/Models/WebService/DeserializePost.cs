using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpark.Models.WebService
{
    //public class DeserializePost
    //{
    //    public List<Post> posts { get; set; }
    //}
    public class DeserializePost
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string URL { get; set; }
        public string featured_image { get; set; }
        public List<Metadata> metadata { get; set; }
    }
    public class Metadata
    {
        public string id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

}
