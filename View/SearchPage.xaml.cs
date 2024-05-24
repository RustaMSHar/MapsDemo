using MapsDemo.Controls;
using MapsDemo.Models;
using MapsDemo.Services;
using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using MapsDemo.Pages;
using System.ComponentModel;
using System.Text;


namespace MapsDemo.View;

public partial class SearchPage : ContentPage, INotifyPropertyChanged
{

    public SearchPage()
	{
		InitializeComponent();
       
    }

    private async void OnSearchByAirportsAndDate(object sender, EventArgs e)
    {
        string departureIata = departureEntry.Text;
        string arrivalIata = arrivalEntry.Text;
        string date = departureDate.Date.ToString("yyyy-MM-dd");

        if (!string.IsNullOrEmpty(departureIata) && !string.IsNullOrEmpty(arrivalIata) && !string.IsNullOrEmpty(date))
        {
            var flights = await ApiService.SearchFlightsByAirportsAndDate(departureIata, arrivalIata, date);
            // Обработка результатов поиска
            flightResults.ItemsSource = flights;
        }
        else
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
        }
    }

    private async void OnSearchByFlightCode(object sender, EventArgs e)
    {
        string flightCode = flightCodeEntry.Text;

        if (!string.IsNullOrEmpty(flightCode))
        {
            try
            {
                var flight = await ApiService.SearchFlightByCode(flightCode);
                if (flight != null)
                {
                    flightResults.ItemsSource = new List<Flight> { flight };
                }
                else
                {
                    await DisplayAlert("Ошибка", "Рейс не найден.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не удалось получить данные рейса. Пожалуйста, попробуйте снова.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Ошибка", "Пожалуйста, введите код рейса.", "OK");
        }
    }
    private async void OnFlightSelected(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null && e.Item is Flight selectedFlight)
        {
            await Navigation.PushModalAsync(new FlightDetailsPage(selectedFlight));
        }
    }

    private void OnSearchModeChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null)
        {
            if (picker.SelectedIndex == 0) // Поиск по аэропортам и дате
            {
                airportDateSearchFrame.IsVisible = true;
                flightCodeSearchFrame.IsVisible = false;
            }
            else if (picker.SelectedIndex == 1) // Поиск по коду рейса
            {
                airportDateSearchFrame.IsVisible = false;
                flightCodeSearchFrame.IsVisible = true;
            }
        }
    }
    private async void OnShowOnMapClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Flight flight)
        {
            await Navigation.PushModalAsync(new FlightMapPage(flight));
        }
        else
        {
            await DisplayAlert("Ошибка", "Не удалось получить данные рейса.", "OK");
        }
    }

    private async void OnAddToNotesClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Flight flight)
        {
            try
            {
                // Получение информации об авиакомпании
                var airlineInfo = await ApiService.GetAirlineInfo(flight.Airline.IataCode);
                var airlineName = airlineInfo?.NameAirline ?? "Неизвестная авиакомпания";

                // Получение информации об аэропортах
                var departureInfo = await ApiService.GetAirportInfo(flight.Departure.IataCode);
                var departureName = departureInfo?.NameAirport ?? "Неизвестный аэропорт";

                var arrivalInfo = await ApiService.GetAirportInfo(flight.Arrival.IataCode);
                var arrivalName = arrivalInfo?.NameAirport ?? "Неизвестный аэропорт";

                // Формирование текста заметки
                string appDataPath = FileSystem.AppDataDirectory;
                string notesFileName = $"{flight.FlightDetails.IataNumber}.notes.txt";

                string noteText = $"Рейс: {flight.FlightDetails.IataNumber}\n" +
                                  $"Статус: {flight.Status}\n" +
                                  $"Авиакомпания: {airlineName}\n" +
                                  $"Отправление: {departureName}\n" +
                                  $"Прибытие: {arrivalName}\n" +
                                  $"Высота: {flight.Geography.Altitude}\n" +
                                  $"Скорость: {flight.Speed.Horizontal}";

                File.WriteAllText(Path.Combine(appDataPath, notesFileName), noteText, Encoding.UTF8);

                await DisplayAlert("Успех", "Данные о рейсе добавлены в заметки.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось получить данные рейса: {ex.Message}", "OK");
            }
        }
        else
        {
            await DisplayAlert("Ошибка", "Не удалось получить данные рейса.", "OK");
        }
    }





}