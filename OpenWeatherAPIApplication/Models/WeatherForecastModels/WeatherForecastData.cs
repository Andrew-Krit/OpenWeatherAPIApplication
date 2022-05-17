// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OpenWeatherAPIApplication.Models.WeatherForecastModels.First_Level_Models;

namespace OpenWeatherAPIApplication.Models.WeatherForecastModels
{
    /// <summary>
    ///     Класс WeatherForecastData
    ///     хранит в себе информацию о городе и его прогноз погоды
    /// </summary>
    [Serializable]
    public class WeatherForecastData
    {
        /// <summary>
        ///     Хранит информацию о городе
        /// </summary>
        public City City;

        /// <summary>
        ///     Хранит информацию о прогнозах
        /// </summary>
        [JsonProperty("List")] public List<Day> Days;

        /// <summary>
        ///     Этот метод показывает прогноз погоды на следующие 5 дней для выбранного города
        /// </summary>
        public void ShowWeatherForecast()
        {
            var finalForecast = Days
                .Where(day => day.ForecastDate.TimeOfDay == TimeSpan.Zero && day.ForecastDate.Date != DateTime.Now.Date)
                .Select(final => final);

            var patternWeather =
                "Date Forecast: {6:dd/mm/yyyy}" +
                "\n+----------------------------------------------------------------------------------------------------------+\n" +
                "|    City    |    Country    | Temperature °C | Wind speed m/s | Weather description |\n" +
                "------------------------------------------------------------------------------------------------------------\n" +
                "|    {0}    |      {1}      |     {2}      |     {3}      |    {4}, {5}  |" +
                "\n+----------------------------------------------------------------------------------------------------------+\n";

            foreach (var dayForecast in finalForecast)
                Console.WriteLine(patternWeather, City.Name, City.Country, dayForecast.TemperatureInfo.Temperature,
                    dayForecast.Wind.Speed, dayForecast.Weather[0].Info, dayForecast.Weather[0].Description,
                    dayForecast.ForecastDate);
        }
    }
}