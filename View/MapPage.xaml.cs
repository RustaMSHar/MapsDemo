using MapsDemo.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using MapsDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MapsDemo.Controls;
using System.Net.NetworkInformation;


namespace MapsDemo
{
    public partial class MainPage : ContentPage
    {
        private List<MapPin> _pins;
        public List<MapPin> Pins
        {
            get { return _pins; }
            set { _pins = value; OnPropertyChanged(); }
        }
        public MainPage()
        {
            
            InitializeComponent();
            LoadFlightsRepeatedly();

            BindingContext = this;
        }
        private async Task LoadFlightsRepeatedly()
        {
            while (true)
            {
                await LoadFlights();
                await Task.Delay(5000); // Приостановка выполнения на 5 секунд
            }
        }

        private async void MapPinClicked(MapPin pin)
        {
            await DisplayAlert("Информация о рейсе", $"Номер Рейса: {pin.Label}\nКод Рейса: {pin.Address} \n", "OK");
        }
        private async Task LoadFlights()
        {

            try
            {
                var flights = await ApiService.GetTracker();
                var newPins = new List<MapPin>();
                // Очистка текущих маркеров на карте
                MyMap.Pins.Clear();
                newPins.Clear();

                foreach (var flight in flights)
                {
                    if (flight.Geography.Latitude != 0 && flight.Geography.Longitude != 0)
                    {

                        var pin = new MapPin(MapPinClicked)
                        {
                            Id = Guid.NewGuid().ToString(),
                            Label = flight.FlightDetails.Number + flight.Arrival.IataCode,
                            Address = flight.FlightDetails.IataNumber,
                            Type = PinType.Place,
                            Position = new Location(flight.Geography.Latitude, flight.Geography.Longitude),
                            IconSrc = "dotred" 
                        };
                        newPins.Add(pin);

                    }
                }
                Pins = newPins; 

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }

    }
}