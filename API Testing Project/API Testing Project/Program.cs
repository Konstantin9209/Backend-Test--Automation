using API_Testing_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

class Program
{
    static void Main(string[] args)
    {
        //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "../../../weatherForecast.json"));

        //var weatherForecastList = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);

        //foreach (var forecast in weatherForecastList)
        //{
        //    Console.WriteLine($"Date: {forecast.Date}, TemperatureC: {forecast.TemperatureC}, Summary: {forecast.Summary}");
        //}
        //WeatherForecast weatherForecast = new WeatherForecast()
        //{
        //    Date = DateTime.Now,
        //    TemperatureC = 32,
        //    Summary = "New Random Test Summary"
        //};
        //string weatherForecastJson = JsonSerializer.Serialize(weatherForecast);
        //Console.WriteLine(weatherForecastJson);
        WeatherForecast weatherForecast = new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureC = 32,
            Summary = "New Random Test Summary"
        };

        string weatherForecastJson = JsonConvert.SerializeObject(weatherForecast, Formatting.Indented);
        Console.WriteLine(weatherForecastJson);
    }
}
