// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

namespace OpenWeatherAPIApplication.Models.WeatherModels.First_Level_Models
{
    /// <summary>
    ///     класс WindInfo
    ///     хранит скорость ветра выбранного города
    /// </summary>
    [Serializable]
    public class WindInfo
    {
        /// <summary>
        ///     Хранит скорость ветра
        /// </summary>
        public double Speed;
    }
}