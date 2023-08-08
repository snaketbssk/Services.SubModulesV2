using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Helpers
{
    /// <summary>
    /// Provides utility methods for working with DateTime objects.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Rounds a DateTime value up to the nearest multiple of the specified TimeSpan increment.
        /// </summary>
        /// <param name="value">The DateTime value to round up.</param>
        /// <param name="snap">The TimeSpan increment to snap to.</param>
        /// <returns>The rounded up DateTime value.</returns>
        public static DateTime ToCeiling(DateTime value, TimeSpan snap)
        {
            var a = value.Ticks + snap.Ticks - 1;
            var b = a / snap.Ticks;
            var c = b * snap.Ticks;
            var result = new DateTime(c, value.Kind);
            return result;
        }

        /// <summary>
        /// Rounds a DateTime value down to the nearest multiple of the specified TimeSpan increment.
        /// </summary>
        /// <param name="value">The DateTime value to round down.</param>
        /// <param name="snap">The TimeSpan increment to snap to.</param>
        /// <returns>The rounded down DateTime value.</returns>
        public static DateTime ToFloor(DateTime value, TimeSpan snap)
        {
            var delta = value.Ticks % snap.Ticks;
            var result = new DateTime(value.Ticks - delta, value.Kind);
            return result;
        }

        /// <summary>
        /// Converts a DateTime value to its year component as a formatted string.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>The year component of the DateTime value as a formatted string.</returns>
        public static string ToYearString(DateTime value)
        {
            var result = value.Year.ToString(DatetimeConstant.YEAR);
            return result;
        }

        /// <summary>
        /// Converts a DateTime value to its month component as a formatted string.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>The month component of the DateTime value as a formatted string.</returns>
        public static string ToMonthString(DateTime value)
        {
            var result = value.Month.ToString(DatetimeConstant.MONTH);
            return result;
        }

        /// <summary>
        /// Converts a DateTime value to its day component as a formatted string.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>The day component of the DateTime value as a formatted string.</returns>
        public static string ToDayString(DateTime value)
        {
            var result = value.Day.ToString(DatetimeConstant.DAY);
            return result;
        }

        /// <summary>
        /// Rounds a DateTime value to the nearest multiple of the specified TimeSpan increment.
        /// </summary>
        /// <param name="value">The DateTime value to round.</param>
        /// <param name="snap">The TimeSpan increment to snap to.</param>
        /// <returns>The rounded DateTime value.</returns>
        /// <example>
        /// <code>
        /// var dt1 = RoundUp(DateTime.Parse("2011-08-11 16:59"), TimeSpan.FromMinutes(15));
        /// // dt1 == {11/08/2011 17:00:00}
        /// </code>
        /// </example>
        public static DateTime ToSnap(DateTime value, TimeSpan snap)
        {
            return new DateTime((value.Ticks + snap.Ticks - 1) / snap.Ticks * snap.Ticks, value.Kind);
        }

        /// <summary>
        /// Counts the occurrences of specific days relative to the current UTC DateTime.
        /// </summary>
        /// <param name="values">An array of DateTime values to be counted.</param>
        /// <returns>A dictionary where keys are the day differences and values are the counts of occurrences.</returns>
        public static Dictionary<int, int> ToCountDays(DateTime[] values)
        {
            var result = new Dictionary<int, int>();
            var nowAt = DateTime.UtcNow;
            foreach (var value in values)
            {
                var day = (int)Math.Floor((nowAt - value).TotalDays);
                if (result.ContainsKey(day))
                {
                    result[day]++;
                }
                else
                {
                    result.Add(day, 1);
                }
            }
            return result;
        }
    }

}
