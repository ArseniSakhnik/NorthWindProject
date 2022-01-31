using System;

namespace NorthWindProject.Application.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetNumberOfMonthInDativeCase(this DateTime date)
        {
            return date.Month switch
            {
                1 => "Января",
                2 => "Февраля",
                3 => "Марта",
                4 => "Апреля",
                5 => "Мая",
                6 => "Июня",
                7 => "Июля",
                8 => "Августа",
                9 => "Сентября",
                10 => "Октября",
                11 => "Ноября",
                12 => "Декабря",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static string GetFormattedToBlankDate(this DateTime date)
        {
            var day = date.Day < 10
                ? $"0{date.Day}"
                : date.Day.ToString();

            var month = date.Month < 10
                ? $"0{date.Month}"
                : date.Month.ToString();

            return $"{day}.{month}.{date.Year}";
        }
    }
}