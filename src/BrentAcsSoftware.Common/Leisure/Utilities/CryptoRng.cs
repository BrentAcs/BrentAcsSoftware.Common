namespace BrentAcsSoftware.Common.Leisure.Utilities;

[ExcludeFromCodeCoverage(Justification = "It's Random")]
public sealed class CryptoRng :IRng
{
   public static CryptoRng Instance { get; } = new CryptoRng();

   public int Next() => throw new NotImplementedException();
   public int Next(int maxValue) => RandomNumberGenerator.GetInt32(maxValue);
   public int Next(int minValue, int maxValue) => RandomNumberGenerator.GetInt32(minValue, maxValue);
   public double Next(double minimum, double maximum) => throw new NotImplementedException();
}
