using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maps : ContentPage
    {
        public Maps()
        {
            InitializeComponent();

        }

        private async void getLocButton_Clicked(object sender, EventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(20));
            var location = await Geolocation.GetLocationAsync(request);

            Position p = new Position(location.Latitude, location.Longitude);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromMeters(90));
            mapView.MoveToRegion(mapSpan);
        }
    }
}