using MapsDemo.Controls;
using MapsDemo.Models;
using MapsDemo.Services;
using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using MapsDemo.Pages;


namespace MapsDemo.View;

public partial class SearchPage : ContentPage
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
            // ��������� ����������� ������
            flightResults.ItemsSource = flights;
        }
        else
        {
            await DisplayAlert("������", "����������, ��������� ��� ����.", "OK");
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
                    await DisplayAlert("������", "���� �� ������.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", "�� ������� �������� ������ �����. ����������, ���������� �����.", "OK");
            }
        }
        else
        {
            await DisplayAlert("������", "����������, ������� ��� �����.", "OK");
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
            if (picker.SelectedIndex == 0) // ����� �� ���������� � ����
            {
                airportDateSearchFrame.IsVisible = true;
                flightCodeSearchFrame.IsVisible = false;
            }
            else if (picker.SelectedIndex == 1) // ����� �� ���� �����
            {
                airportDateSearchFrame.IsVisible = false;
                flightCodeSearchFrame.IsVisible = true;
            }
        }
    }



}