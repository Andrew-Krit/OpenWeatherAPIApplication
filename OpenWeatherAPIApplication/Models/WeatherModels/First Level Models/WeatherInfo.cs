// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models
{
    /// <summary>
    ///     Класс WeatherInfo
    ///     хранит погоду города и её краткое описание
    /// </summary>
    [Serializable]
    public class WeatherInfo
    {
        /// <summary>
        ///     Хранит информацию о погоде
        /// </summary>
        [JsonProperty("Main")] public string Info;

        /// <summary>
        ///     Хранит краткое описание погоды
        /// </summary>
        public string Description;
    }
}