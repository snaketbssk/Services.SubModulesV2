using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ToCeiling(DateTime value, TimeSpan snap)
        {
            var a = value.Ticks + snap.Ticks - 1;
            var b = a / snap.Ticks;
            var c = b * snap.Ticks;
            var result = new DateTime(c, value.Kind);
            return result;
        }

        public static DateTime ToFloor(DateTime value, TimeSpan snap)
        {
            var delta = value.Ticks % snap.Ticks;
            var result = new DateTime(value.Ticks - delta, value.Kind);
            return result;
        }

        public static string ToYearString(DateTime value)
        {
            var result = value.Year.ToString(DatetimeConstant.YEAR);
            return result;
        }

        public static string ToMonthString(DateTime value)
        {
            var result = value.Month.ToString(DatetimeConstant.MONTH);
            return result;
        }

        public static string ToDayString(DateTime value)
        {
            var result = value.Day.ToString(DatetimeConstant.DAY);
            return result;
        }

        // var dt1 = RoundUp(DateTime.Parse("2011-08-11 16:59"), TimeSpan.FromMinutes(15));
        // dt1 == {11/08/2011 17:00:00}
        public static DateTime ToSnap(DateTime value, TimeSpan snap)
        {
            return new DateTime((value.Ticks + snap.Ticks - 1) / snap.Ticks * snap.Ticks, value.Kind);
        }
    }
}
