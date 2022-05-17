// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OpenWeatherAPIApplication
{
    /// <summary>
    ///     Класс ObjectExtensions
    ///     является расширением для типа object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Получение байтового представления объекта.
        /// </summary>
        /// <returns>Байтовое представление объекта</returns>
        public static byte[] GetBytes(this object data)
        {
            var binaryFormatter = new BinaryFormatter();
            using var memoryStream = new MemoryStream();

            binaryFormatter.Serialize(memoryStream, data);

            return memoryStream.ToArray();
        }
    }
}