namespace Services.SubModules.DataLayers.Constants
{
    /// <summary>
    /// Provides constant values for database context-related operations.
    /// </summary>
    public static class ContextConstant
    {
        /// <summary>
        /// Represents the format for storing decimal values with precision (18,8).
        /// </summary>
        public const string DECIMAL = "decimal(18,8)";

        /// <summary>
        /// Represents the format for storing coordinates as decimal values with precision (18,8).
        /// </summary>
        public const string COORDINATES = "decimal(18,8)";

        /// <summary>
        /// Represents a constant to generate a new GUID using the NEWID() function.
        /// </summary>
        public const string NEW_GUID = "NEWID()";

        /// <summary>
        /// Represents a constant to retrieve the current UTC date and time using the GETUTCDATE() function.
        /// </summary>
        public const string GET_UTC_DATE = "GETUTCDATE()";
    }
}
