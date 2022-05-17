// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models
{
    /// <summary>
    ///     Класс CoordinationsInfo
    ///     хранит информацию о широте и долготе города
    /// </summary>
    [Serializable]
    public class CoordinationsInfo
    {
        /// <summary>
        ///     Долгота города
        /// </summary>
        [JsonProperty("Lon")] public double Longitude;

        /// <summary>
        ///     Широта города
        /// </summary>
        [JsonProperty("Lat")] public double Latitude;
    }
}