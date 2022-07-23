namespace BrentAcsSoftware.Common.Leisure.Utilities;

[ExcludeFromCodeCoverage(Justification = "It's Random")]
public sealed class SimpleRng : IRng
{
   private readonly Random _random = new();

   public static IRng Instance { get; } = new SimpleRng();

   public int Next() => _random.Next();
   public int Next(int maxValue) => _random.Next(maxValue);
   public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
   public double Next(double minimum, double maximum) => _random.NextDouble() * (maximum - minimum) + minimum;
}
