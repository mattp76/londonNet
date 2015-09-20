using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentmyhouse.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public int? Bed { get; set; }
        public string Type { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Image1 { get; set; }
        public string postedBy { get; set; }
    }
}