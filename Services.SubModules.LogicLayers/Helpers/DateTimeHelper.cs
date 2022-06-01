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
    }
}
