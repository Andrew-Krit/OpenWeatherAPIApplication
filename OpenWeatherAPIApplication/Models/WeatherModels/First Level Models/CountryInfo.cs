// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models
{
    /// <summary>
    ///     Класс CountyInfo
    ///     хранит информацию о стране выбранного города
    /// </summary>
    [Serializable]
    public class CountryInfo
    {
        /// <summary>
        ///     Название страны города
        /// </summary>
        [JsonProperty("Country")] public string CountryCode;
    }
}