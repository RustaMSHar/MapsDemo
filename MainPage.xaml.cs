using Microsoft.Maui.Controls;
using MapsDemo.Models;
using MapsDemo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapsDemo
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            LoadFlightData();
        }


        private async void LoadFlightData()
        {
            var flightData = await ApiService.GetFlightData();
            if (flightData != null && flightData.geography != null)
            {
                foreach (var geo in flightData.geography)
                {
                    var position = new Position(geo.latitude, geo.longitude);
                    var marker = new Marker
                    {
                        Position = position,
                        Label = "Aircraft"
                    };
                    map.AddMarker(marker);
                }
            }
        }

    }

}
