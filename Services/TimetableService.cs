using MapsDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MapsDemo.Services
{
    public static class TimetableService
    {
        private static readonly string ApiKey = "2d83a2-a21b99";

        // Метод для поиска по аэропорту и дате
        public static async Task<List<TimetableResponse>> GetTimetableAsync(string departureIata, string date)
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://aviation-edge.com/v2/public/timetable?iataCode={departureIata}&type=departure&key={ApiKey}&dep_schTime={date}T00:00:00.000";
                var response = await httpClient.GetStringAsync(url);

                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("Пустой ответ от API");
                }

                var timetable = JsonConvert.DeserializeObject<List<TimetableResponse>>(response);

                if (timetable == null)
                {
                    throw new Exception("Не удалось десериализовать данные");
                }

                return timetable;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Ошибка HTTP запроса: " + httpEx.Message, httpEx);
            }
            catch (JsonException jsonEx)
            {
                throw new Exception("Ошибка обработки JSON: " + jsonEx.Message, jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось получить данные расписания: " + ex.Message, ex);
            }
        }
    }
}
