using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OMDbAPI : ContentPage
    {
        public OMDbAPI()
        {
            InitializeComponent();
        }

        static string GetJson(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = 0;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        static List<MovieModel> DesJson(string json)
        {
            List<MovieModel> tempList = new List<MovieModel>();

            tempList.Add(JsonConvert.DeserializeObject<MovieModel>(json));

            return tempList;
        }

        private void jsonBtn_Clicked(object sender, EventArgs e)
        {
            string search = entryName.Text;
            List<MovieModel> movieList = new List<MovieModel>();

            if (!string.IsNullOrEmpty(search))
            {
                movieList = DesJson(GetJson(@"http://www.omdbapi.com/?apikey=343e2c9a&t=" + search));
            }
            else
            {
                DisplayAlert("No title", "Please enter a title", "OK");
            }

            foreach (var item in movieList)
            {

                if (item.Poster == null)
                {
                    DisplayAlert("Not Found", "Nothing found", "OK");
                    break;
                }
                else
                {
                    labelGenre.Text = item.Genre.ToString();
                    labelIMDB.Text = item.imdbRating;
                    labelTitle.Text = item.Title;
                    labelYear.Text = item.Year;
                    labelCountry.Text = item.Country;
                    imgPoster.Source = item.Poster;
                }
            }
        }
    }
}