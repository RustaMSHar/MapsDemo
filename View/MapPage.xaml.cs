using MapsDemo.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using MapsDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace MapsDemo
{
    public partial class MainPage : ContentPage
    {
       
        

        public MainPage()
        {
            InitializeComponent();

            LoadFlightsRepeatedly();

        }
        private async Task LoadFlightsRepeatedly()
        {
            while (true)
            {
                await LoadFlights();
                await Task.Delay(5000); // Приостановка выполнения на 5 секунд
            }
        }

        private async Task LoadFlights()
        {
            try
            {
                var flights = await ApiService.GetTracker();
                // Очистка текущих маркеров на карте
                MyMap.Pins.Clear();

                foreach (var flight in flights)
                {
                    if (flight.Geography.Latitude != 0 && flight.Geography.Longitude != 0)
                    {
                        var pin = new Pin
                        {
                            Label = flight.FlightDetails.Number,
                            Address = flight.FlightDetails.IcaoNumber,
                            Type = PinType.Place,
                            Location = new Location(flight.Geography.Latitude, flight.Geography.Longitude)
                        };

                        MyMap.Pins.Add(pin);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
