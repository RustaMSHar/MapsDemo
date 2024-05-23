using MapsDemo.Models;
using MapsDemo.Services;
using Microsoft.Maui.Controls;

namespace MapsDemo.Pages;

public partial class FlightDetailsPage : ContentPage
{
    public FlightDetailsPage(Flight flight)
    {
        InitializeComponent();
        BindingContext = flight;
        LoadAirlineInfo(flight.Airline.IataCode);
        LoadAirportInfo(flight.Departure.IataCode, true);
        LoadAirportInfo(flight.Arrival.IataCode, false);
    }

    private async void LoadAirlineInfo(string iataCode)
    {
        var airlineInfo = await ApiService.GetAirlineInfo(iataCode);
        if (airlineInfo != null)
        {
            AirlineLabel.Text = airlineInfo.NameAirline;
        }
        else
        {
            AirlineLabel.Text = "Неизвестная авиакомпания";
        }
    }

    private async void LoadAirportInfo(string iataCode, bool isDeparture)
    {
        var airportInfo = await ApiService.GetAirportInfo(iataCode);
        if (airportInfo != null)
        {
            if (isDeparture)
            {
                DepartureLabel.Text = airportInfo.NameAirport;
            }
            else
            {
                ArrivalLabel.Text = airportInfo.NameAirport;
            }
        }
        else
        {
            if (isDeparture)
            {
                DepartureLabel.Text = "Неизвестный аэропорт";
            }
            else
            {
                ArrivalLabel.Text = "Неизвестный аэропорт";
            }
        }
    }
}
