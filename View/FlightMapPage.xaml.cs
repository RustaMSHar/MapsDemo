using MapsDemo.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
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

        pin.MarkerClicked += OnPinClicked; // Add event handler for pin click

        MyMap.Pins.Add(pin);
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(600)));
    }

    private async void OnPinClicked(object sender, PinClickedEventArgs e)
    {
        var flightInfo = $"Рейс: {Flight.FlightDetails.Number}\n" +
                         $"IATA: {Flight.FlightDetails.IataNumber}\n" +
                         $"ICAO: {Flight.FlightDetails.IcaoNumber}\n" +
                         $"Авиакомпания: {Flight.Airline.IataCode} ({Flight.Airline.IcaoCode})\n" +
                         $"Скорость: {Flight.Speed.Horizontal} км/ч\n" +
                         $"Высота: {Flight.Geography.Altitude} м\n" +
                         $"Статус: {Flight.Status}\n" +
                         $"Аэропорт отправления: {Flight.Departure.IataCode} ({Flight.Departure.IcaoCode})\n" +
                         $"Аэропорт прибытия: {Flight.Arrival.IataCode} ({Flight.Arrival.IcaoCode})";

        await DisplayAlert("Информация о рейсе", flightInfo, "OK");
    }

    private void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        // You can handle map clicks here if needed
    }
}
