using MapsDemo.Models;
using MapsDemo.Services;
using Microsoft.Maui.Controls;


namespace MapsDemo.Pages;

public partial class FlightDetailsPageData : ContentPage
{
	public FlightDetailsPageData(TimetableResponse timetableResponse)
	{
		InitializeComponent();
        BindingContext = timetableResponse;
        LoadAirlineInfo(timetableResponse.Airline.IataCode);
        LoadAirportInfo(timetableResponse.Departure.IataCode, true);
        LoadAirportInfo(timetableResponse.Arrival.IataCode, false);

        
        DepartureTimeLabel.Text = timetableResponse.Departure.ScheduledTime;
        ArrivalTimeLabel.Text = timetableResponse.Arrival.ScheduledTime;

        DepartureTerminalLabel.Text = timetableResponse.Departure.Terminal;
        ArrivalTerminalLabel.Text = timetableResponse.Arrival.Terminal;
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