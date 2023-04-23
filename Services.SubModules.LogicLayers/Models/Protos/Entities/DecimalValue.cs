namespace Services.SubModules.Protos
{
    public partial class DecimalGrpcModel
    {
        private const decimal NanoFactor = 1_000_000_000;

        public DecimalGrpcModel(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }

        public static implicit operator decimal(DecimalGrpcModel decimalValue) => decimalValue.ToDecimal();

        public static implicit operator DecimalGrpcModel(decimal value) => FromDecimal(value);

        public decimal ToDecimal()
        {
            return Units + Nanos / NanoFactor;
        }

        public static DecimalGrpcModel FromDecimal(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalGrpcModel(units, nanos);
        }
    }
}
