using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Helpers
{
    class Constants
    {
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "CUMAZNZFRKG0LF2KORI5C3JDFHIEPJSNDNSGIYZKDYONVBNU";
        public const string CLIENT_SECRET = "4ULH4GCWW0HFCRGLGD4IJORGHUCKIUD2GQDAJDBBCT2CYPMN";
    }
}
/*https://api.foursquare.com/v2/venues/search?ll=40.7,-74&client_id=CLIENT_ID&client_secret=CLIENT_SECRET&v=YYYYMMDD*/