// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models;

namespace OpenWeatherAPIApplication.Models.WeatherModels
{
    /// <summary>
    ///     Класс WeatherData
    ///     хранит информацию о погоде на текущий момент для выбранного города
    /// </summary>
    [Serializable]
    public class WeatherData
    {
        /// <summary>
        ///     Хранит название города
        /// </summary>
        [JsonProperty("Name")] public string CityName;

        /// <summary>
        ///     Хранит информацию в стране города
        /// </summary>
        [JsonProperty("Sys")] public CountryInfo CountryInfo;

        /// <summary>
        ///     Хранит информацию о ветре
        /// </summary>
        public WindInfo Wind;

        /// <summary>
        ///     Хранит информацию о температуре города
        /// </summary>
        [JsonProperty("Main")] public TemperatureInfo TemperatureInfo;

        /// <summary>
        ///     Хранит информацию о погоде
        /// </summary>
        public List<WeatherInfo> Weather;

        /// <summary>
        ///     Хранит соординаты города
        /// </summary>
        [JsonProperty("Coord")] public CoordinationsInfo Coordinations;

        /// <summary>
        ///     Дата обновления скачанной погоды
        /// </summary>
        public DateTime DownloadDate = DateTime.Now;

        /// <summary>
        ///     Этот метод показывает погоду выбранного города
        /// </summary>
        public void ShowWeatherNow()
        {
            var patternWeather =
                "Weather for today, Downloaded: {6}" +
                "\n+----------------------------------------------------------------------------------------------------------+\n" +
                "|    City    |    Country    | Temperature °C | Wind speed m/s | Weather description |\n" +
                "------------------------------------------------------------------------------------------------------------\n" +
                "|    {0}    |      {1}      |     {2}      |     {3}      |    {4}, {5}  |" +
                "\n+----------------------------------------------------------------------------------------------------------+\n";


            Console.WriteLine(patternWeather, CityName, CountryInfo.CountryCode, TemperatureInfo.Temperature,
                Wind.Speed, Weather[0].Info, Weather[0].Description, DownloadDate);
        }
    }
}