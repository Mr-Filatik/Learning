namespace GrpcService2.ProtoBuf.Messages
{
    public partial class DecimalGrpc
    {
        private const decimal NanoFactor = 1_000_000_000;

        public DecimalGrpc(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }

        public static implicit operator decimal(DecimalGrpc decimalValue) => decimalValue.ToDecimal();

        public static implicit operator DecimalGrpc(decimal value) => FromDecimal(value);

        public decimal ToDecimal()
        {
            return this.Units + this.Nanos / NanoFactor;
        }

        public static DecimalGrpc FromDecimal(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalGrpc(units, nanos);
        }
    }
}
