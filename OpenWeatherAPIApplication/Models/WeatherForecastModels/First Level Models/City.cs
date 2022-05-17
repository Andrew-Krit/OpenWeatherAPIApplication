// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

namespace OpenWeatherAPIApplication.Models.WeatherForecastModels.First_Level_Models
{
    /// <summary>
    ///     Класс City
    ///     хранит название города и его страну
    /// </summary>
    [Serializable]
    public class City
    {
        /// <summary>
        ///     Название города
        /// </summary>
        public string Name;

        /// <summary>
        ///     Название страны города
        /// </summary>
        public string Country;
    }
}