namespace Services.SubModules.Protos
{
    /// <summary>
    /// Represents a decimal value with a scaled fractional part using Protobuf.
    /// </summary>
    public partial class DecimalGrpcModel
    {
        private const decimal NanoFactor = 1_000_000_000;

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalGrpcModel"/> class.
        /// </summary>
        /// <param name="units">The whole number part of the decimal value.</param>
        /// <param name="nanos">The scaled fractional part of the decimal value.</param>
        public DecimalGrpcModel(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }

        /// <summary>
        /// Implicitly converts a <see cref="DecimalGrpcModel"/> to a .NET <see cref="decimal"/> value.
        /// </summary>
        /// <param name="decimalValue">The <see cref="DecimalGrpcModel"/> value to convert.</param>
        /// <returns>The converted .NET <see cref="decimal"/> value.</returns>
        public static implicit operator decimal(DecimalGrpcModel decimalValue) => decimalValue.ToDecimal();

        /// <summary>
        /// Implicitly converts a .NET <see cref="decimal"/> value to a <see cref="DecimalGrpcModel"/>.
        /// </summary>
        /// <param name="value">The .NET <see cref="decimal"/> value to convert.</param>
        /// <returns>The converted <see cref="DecimalGrpcModel"/>.</returns>
        public static implicit operator DecimalGrpcModel(decimal value) => FromDecimal(value);

        /// <summary>
        /// Converts the <see cref="DecimalGrpcModel"/> to a .NET <see cref="decimal"/> value.
        /// </summary>
        /// <returns>The equivalent .NET <see cref="decimal"/> value.</returns>
        public decimal ToDecimal()
        {
            return Units + Nanos / NanoFactor;
        }

        /// <summary>
        /// Converts a .NET <see cref="decimal"/> value to a <see cref="DecimalGrpcModel"/>.
        /// </summary>
        /// <param name="value">The .NET <see cref="decimal"/> value to convert.</param>
        /// <returns>The converted <see cref="DecimalGrpcModel"/>.</returns>
        public static DecimalGrpcModel FromDecimal(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalGrpcModel(units, nanos);
        }
    }
}
