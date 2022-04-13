using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppMitAlles
{
    class MovieModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Year")]
        public string Year { get; set; }
        [JsonProperty("imdbRating")]
        public string imdbRating { get; set; }
        [JsonProperty("Poster")]
        public string Poster { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
    }
}
