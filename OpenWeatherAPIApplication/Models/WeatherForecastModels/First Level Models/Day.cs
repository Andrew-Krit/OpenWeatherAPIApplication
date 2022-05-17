// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models;

namespace OpenWeatherAPIApplication.Models.WeatherForecastModels.First_Level_Models
{
    /// <summary>
    ///     Класс Day
    ///     хранит в себе информацию о погоде на конкретный день
    /// </summary>
    [Serializable]
    public class Day
    {
        /// <summary>
        ///     Хранит время расчёта погоды
        /// </summary>
        public double Dt;

        /// <summary>
        ///     Хранит информацию о температуре
        /// </summary>
        [JsonProperty("Main")] public TemperatureInfo TemperatureInfo;

        /// <summary>
        ///     Хранит информацию о погоде
        /// </summary>
        public List<WeatherInfo> Weather;

        /// <summary>
        ///     Хранит информацию о ветре
        /// </summary>
        public WindInfo Wind;

        /// <summary>
        ///     Дата прогноза погоды
        /// </summary>
        [JsonProperty("dt_txt")] public DateTime ForecastDate;
    }
}