namespace Donker.SystemTrayTools.WeekNumber.Helpers;

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
        var lastDayOfYear = new DateTimeOffset(year, 12, 31, 0, 0, 0, TimeSpan.Zero);

        return lastDayOfYear.DayOfWeek switch
        {
            DayOfWeek.Thursday => 53,
            DayOfWeek.Friday => DateTime.IsLeapYear(year) ? 53 : 52,
            DayOfWeek.Saturday or DayOfWeek.Sunday => 52,
            _ => 1,
        };
    }
}