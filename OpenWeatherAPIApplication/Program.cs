// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeatherAPIApplication.Models.WeatherForecastModels;
using OpenWeatherAPIApplication.Models.WeatherModels;

namespace OpenWeatherAPIApplication
{
    /// <summary>
    ///     Класс Program
    ///     является основным классом программы
    /// </summary>
    public class Program
    {
        private const string ApiKey = "ef485c934d378d96ca381a71b30fd598";

        private static ObservableDictionary<string, WeatherData> _forecastCache =
            new ObservableDictionary<string, WeatherData>();

        private enum City
        {
            Tokyo,
            Minsk,
            Praha,
            Tbilisi,
            Moscow
        }

        private static async Task Main(string[] args)
        {
            var loadedDictionary = Storage.Load<Dictionary<string, WeatherData>>();

            if (loadedDictionary != null) 
                _forecastCache = new ObservableDictionary<string, WeatherData>(loadedDictionary);

            while (true)
                try
                {
                    var selectedCity = "underfined";

                    Console.WriteLine(
                        "\n1 Choose Tokyo - key 1 \n" +
                        "2 Choose Minsk - key 2 \n" +
                        "3 Choose Praha - key 3 \n" +
                        "4 Choose Tbilisi - key 4 \n" +
                        "5 Choose Moscow - key 5 \n" +
                        "6 Choose custom city \n" +
                        "7 Previously requested cities \n" +
                        "You can press 'C' to clear console.\n");

                    var pressedKey = Console.ReadKey(true).Key;

                    switch (pressedKey)
                    {
                        case ConsoleKey.D1:

                            selectedCity = nameof(City.Tokyo);

                            break;

                        case ConsoleKey.D2:

                            selectedCity = nameof(City.Minsk);

                            break;

                        case ConsoleKey.D3:

                            selectedCity = nameof(City.Praha);

                            break;

                        case ConsoleKey.D4:

                            selectedCity = nameof(City.Tbilisi);

                            break;

                        case ConsoleKey.D5:

                            selectedCity = nameof(City.Moscow);

                            break;

                        case ConsoleKey.D6:

                            Console.Write("You city: ");
                            selectedCity = Console.ReadLine();

                            if (Enum.IsDefined(typeof(City), selectedCity))
                                throw new Exception("Inputed city is already included in the list");

                            break;

                        case ConsoleKey.D7:

                            ShowPreviousRequests();

                            break;

                        case ConsoleKey.C:

                            Console.Clear();

                            break;
                    }

                    if (selectedCity != "underfined")
                    {
                        var weather = await DownloadWeather(selectedCity);

                        if (weather != null)
                        {
                            _forecastCache.Add(selectedCity, weather);
                            weather.ShowWeatherNow();
                        }

                        var forecast = await DownloadForecast(selectedCity);
                        Console.WriteLine();
                        
                        if(forecast != null)
                            forecast.ShowWeatherForecast();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Something goes wrong..: {exception.Message}");
                }
        }

        /// <summary>
        ///     Получает погоду на текущий момент
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <returns>Данные погоды на текущий момент</returns>
        public static async Task<WeatherData> DownloadWeather(string cityName)
        {
            try
            {
                var web = new WebClient();
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={ApiKey}";
                var jsonData = await web.DownloadStringTaskAsync(url);

                web.Dispose();

                var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonData);

                return weatherData;
            }
            catch (WebException webException)
                when (webException.Status == WebExceptionStatus.ProtocolError)
            {
                _forecastCache[cityName].ShowWeatherNow();
            }
            catch (WebException webException)
                when ((webException.Response as HttpWebResponse)?.StatusCode ==
                      HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Something goes wrong..: {webException.Message}");
            }
            catch (WebException webException)
                when ((webException.Response as HttpWebResponse)?.StatusCode ==
                      HttpStatusCode.InternalServerError)
            {
                _forecastCache[cityName].ShowWeatherNow();
            }
            catch (WebException)
            {
                _forecastCache[cityName].ShowWeatherNow();
            }

            return null;
        }

        /// <summary>
        ///     Получает прогноз погоды на следующие 5 дней
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <returns>Данные прогноза погоды</returns>
        public static async Task<WeatherForecastData> DownloadForecast(string cityName)
        {
            try
            {
                var web = new WebClient();
                var url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid={ApiKey}";
                var jsonData = await web.DownloadStringTaskAsync(url);

                web.Dispose();

                var weatherForecastDate = JsonConvert.DeserializeObject<WeatherForecastData>(jsonData);

                return weatherForecastDate;
            }
            catch (WebException webException)
                when (webException.Status == WebExceptionStatus.ProtocolError)
            {
                Console.WriteLine($"Something goes wrong..: {webException.Message}");
            }
            catch (WebException webException)
                when ((webException.Response as HttpWebResponse)?.StatusCode ==
                      HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Something goes wrong..: {webException.Message}");
            }
            catch (WebException webException)
                when ((webException.Response as HttpWebResponse)?.StatusCode ==
                      HttpStatusCode.InternalServerError)
            {
                Console.WriteLine($"Something goes wrong..: {webException.Message}");
            }
            catch (WebException webException)
            {
                Console.WriteLine($"Something goes wrong..: {webException.Message}");
            }

            return null;
        }

        public static void ShowPreviousRequests()
        {
            try
            {
                if (!File.Exists(Storage.FilePath))
                    throw new Exception("You have not made any requests yet...");

                Console.WriteLine("Previously requested cities: ");

                _forecastCache =
                    new ObservableDictionary<string, WeatherData>(
                        Storage.Load<Dictionary<string, WeatherData>>());

                foreach (var forecast in _forecastCache)
                    forecast.Value.ShowWeatherNow();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Something goes wrong..: {exception.Message}");
            }
        }
    }
}