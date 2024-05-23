﻿using MapsDemo.Models;
using Newtonsoft.Json;

namespace MapsDemo.Services
{
    public static class ApiService
    {

        private static readonly string ApiKey = "2d83a2-a21b99";

        // Метод для поиска по аэропорту и дате
        public static async Task<List<Flight>> SearchFlightsByAirportsAndDate(string departureIata, string arrivalIata, string date)
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://aviation-edge.com/v2/public/flights?key={ApiKey}&depIata={departureIata}&arrIata={arrivalIata}&depDate={date}";
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<Flight>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve SearchFlightsByAirportsAndDate by code", ex);
            }

        }

        // Метод для поиска по коду рейса
        public static async Task<Flight> SearchFlightByCode(string flightCode)
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://aviation-edge.com/v2/public/flights?key={ApiKey}&flightIata={flightCode}";
                var response = await httpClient.GetStringAsync(url);
                var flights = JsonConvert.DeserializeObject<List<Flight>>(response);
                return flights?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve SearchFlightByCode by code", ex);
            }

        }

        // Метод для получения трекера
        public static async Task<List<Flight>> GetTracker()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync($"https://aviation-edge.com/v2/public/flights?key={ApiKey}&limit=10");
                return JsonConvert.DeserializeObject<List<Flight>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve GetTracker by code", ex);
            }
        }

        public static async Task<AirlineInfo> GetAirlineInfo(string iataCode)
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://aviation-edge.com/v2/public/airlineDatabase?codeIataAirline={iataCode}&key={ApiKey}";
                var response = await httpClient.GetStringAsync(url);
                var airlineInfoList = JsonConvert.DeserializeObject<List<AirlineInfo>>(response);
                return airlineInfoList?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve GetAirlineInfo by code", ex);
            }

        }
        public static async Task<AirportInfo> GetAirportInfo(string iataCode)
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://aviation-edge.com/v2/public/airportDatabase?codeIataAirport={iataCode}&key={ApiKey}";
                var response = await httpClient.GetStringAsync(url);
                var airportInfoList = JsonConvert.DeserializeObject<List<AirportInfo>>(response);
                return airportInfoList?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve GetAirportInfo by code", ex);
            }

        }

    }
}
