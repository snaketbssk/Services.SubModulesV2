namespace Services.SubModules.LogicLayers.Helpers
{
    public static class StringHelper
    {
        public static string ToDigits(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var result = new string(value.Where(char.IsDigit).ToArray());
                return result;
            }
            return value;
        }
    }
}
