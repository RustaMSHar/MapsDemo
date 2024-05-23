
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using MapsDemo.Models;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;

namespace MapsDemo.View;

public partial class FlightMapPage : ContentPage
{
    public Flight Flight { get; private set; }
    public FlightMapPage(Flight flight)
	{
		InitializeComponent();
        Flight = flight;
        ShowFlightOnMap();
    }


    private void ShowFlightOnMap()
    {
        var position = new Location(Flight.Geography.Latitude, Flight.Geography.Longitude);
        var pin = new Pin
        {
            Label = Flight.FlightDetails.Number,
            Address = Flight.FlightDetails.IcaoNumber,
            Type = PinType.Place,
            Location = position
        };

        MyMap.Pins.Add(pin);
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(600)));
    }
}