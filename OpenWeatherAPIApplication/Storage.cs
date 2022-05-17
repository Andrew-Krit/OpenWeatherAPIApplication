// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OpenWeatherAPIApplication
{
    /// <summary>
    ///     Хранилище данных.
    /// </summary>
    public static class Storage
    {
        /// <summary>
        ///     Файл для хранения данных
        /// </summary>
        public const string FilePath = @"C:\Users\user\Desktop\forecastCache";

        /// <summary>
        ///     Сохранение объекта в файл.
        /// </summary>
        /// <param name="data">Объект</param>
        /// <typeparam name="T">Тип объекта</typeparam>
        public static void Save<T>(T data)
        {
            try
            {
                var bytes = data.GetBytes();

                File.WriteAllBytes(FilePath, bytes);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        ///     Загрузка объекта из файла.
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        public static T Load<T>()
        {
            try
            {
                if (!File.Exists(FilePath))
                    throw new Exception($"Cache data is empty or was deleted.");

                var bytes = File.ReadAllBytes(FilePath);

                using var memoryStream = new MemoryStream(bytes);

                var binaryFormatter = new BinaryFormatter();

                return (T) binaryFormatter.Deserialize(memoryStream);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return default;
            }
        }
    }
}