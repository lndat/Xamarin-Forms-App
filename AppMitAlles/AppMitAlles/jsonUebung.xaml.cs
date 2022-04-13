using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppMitAlles.dateJson;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class jsonUebung : ContentPage
    {
        public jsonUebung()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            jsonDateLabel.Text = DesJson(GetJson(@"http://date.jsontest.com/")).ToString();
            stopWatch.Stop();
            timerLabel.Text = "Command ending after: " + stopWatch.Elapsed.TotalMilliseconds + " ms";

            //var msTimer = DateTime.Now;
            //jsonDateLabel.Text = DesJson(GetJson(@"http://date.jsontest.com/")).ToString();
            //timerLabel.Text = (DateTime.Now - msTimer).TotalMilliseconds.ToString() + " ms";
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
        static string DesJson(string json)
        {
            var jsonDate = JsonConvert.DeserializeObject<DateJson>(json);
            return $"Date: " + jsonDate.Date + "\nms since epoch: " + jsonDate.Milliseconds_since_epoch + "\nTime: " + jsonDate.Time;
        }
    }
}