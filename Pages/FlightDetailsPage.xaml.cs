using MapsDemo.Models;
using MapsDemo.Controls;
using MapsDemo.View;
using MapsDemo.Services;

namespace MapsDemo.Pages;


public partial class FlightDetailsPage : ContentPage
{

	public FlightDetailsPage(Flight flight)
	{
		InitializeComponent();
        BindingContext = flight;
    }
}