using AppServices.Interfaces;
using System;

namespace AppServices
{
    /// <summary>
    /// This service translates the time in to text
    /// </summary>
    public class ClockService : IClockService
    {
        /// <summary>
        /// Private constant Hours and Minutes Text
        /// </summary>
        private static readonly string[] hours = { "Twelve", "One", "Two", "Three", "Four",
                            "Five", "Six", "Seven", "Eight", "Nine",
                            "Ten", "Eleven", "Twelve", "One",
                            "Two", "Three", "Four", "Five",
                            "Six", "Seven", "Eight", "Nine",
                            "Ten", "Eleven", "Twelve" };

        private static readonly string[] minutes = { "Zero", "One", "Two", "Three", "Four",
                            "Five", "Six", "Seven", "Eight", "Nine",
                            "Ten", "Eleven", "Twelve", "Thirteen",
                            "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                            "Eighteen", "Nineteen", "Twenty", "Twenty One",
                            "Twenty Two", "Twenty Three", "Twenty Four",
                            "Twenty Five", "Twenty Six", "Twenty Seven",
                            "Twenty Eight", "Twenty Nine" };

        /// <summary>
        /// To convert input time to text
        /// </summary>
        /// <param name="time">Input Parameter</param>
        public string getTimeText(string time)
        {
            var value = time.Split(":");
            return translateTime(int.Parse(value[0]), int.Parse(value[1]));
        }

        /// <summary>
        /// To get current time text
        /// </summary>
        public string getCurrentTimeText()
        {
           return translateTime(DateTime.Now.Hour, DateTime.Now.Minute);
        }

        /// <summary>
        /// To translate input time to text
        /// </summary>
        /// <param name="h">hours</param>
        /// <param name="m">minutes</param>
        private static string translateTime(int h, int m)
        {
            var timeText = string.Empty;

            switch (m)
            {
                case 0:
                    timeText = $"{hours[h]} o' clock ";
                    break;
                case 15:
                    timeText = $"Quarter Past {hours[h]}";
                    break;
                case 30:
                    timeText = $"Half Past {hours[h]}";
                    break;
                case 45:
                    timeText = $"Quarter To {hours[(h % 12) + 1]}";
                    break;
                default:
                    {
                        if (m <= 30)
                            timeText = $"{minutes[m]} Past { hours[h]}";

                        else if (m > 30)
                            timeText = $"{minutes[60 - m]} To {hours[(h % 12) + 1]}";
                    }
                    break;
            }

            return timeText;
        }
    }
}
