// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models
{
    /// <summary>
    ///     Класс TemperatureInfo
    ///     хранит информацию о температуре, давлении и влажности города
    /// </summary>
    [Serializable]
    public class TemperatureInfo
    {
        /// <summary>
        ///     Температура в городе
        /// </summary>
        [JsonProperty("Temp")] public double Temperature;

        /// <summary>
        ///     Атмосферное давление в городе
        /// </summary>
        public double Pressure;

        /// <summary>
        ///     Уровень влажности в городе
        /// </summary>
        public double Humidity;
    }
}