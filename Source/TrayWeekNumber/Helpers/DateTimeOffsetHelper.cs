using System;

namespace TrayWeekNumber.Helpers
{
    public static class DateTimeOffsetHelper
    {
        public static int GetIso8601DayNumberOfWeek(DateTimeOffset date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)date.DayOfWeek;
        }

        public static int GetIso8601WeekNumber(DateTimeOffset date)
        {
            int ordinalDate = date.DayOfYear;
            int weekDay = GetIso8601DayNumberOfWeek(date);

            int weekNumber = (ordinalDate - weekDay + 10) / 7;

            if (weekNumber < 1)
                weekNumber = GetIso8601LastWeek(date.Year - 1);
            else if (weekNumber > 52)
                weekNumber = GetIso8601LastWeek(date.Year);

            return weekNumber;
        }

        public static int GetIso8601LastWeek(int year)
        {
            DateTimeOffset lastDayOfYear = new DateTimeOffset(year, 12, 31, 0, 0, 0, TimeSpan.Zero);

            switch (lastDayOfYear.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    return 53;
                case DayOfWeek.Friday:
                    return DateTime.IsLeapYear(year) ? 53 : 52;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 52;
                default:
                    return 1;
            }
        }
    }
}