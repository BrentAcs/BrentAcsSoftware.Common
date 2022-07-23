namespace BrentAcsSoftware.Common.Leisure.Utilities;

public interface IDice
{
   int NextD4();
   int NextD6();
   int NextD8();
   int NextD10();
   int NextD100();
}

[ExcludeFromCodeCoverage(Justification = "It's Random")]
public class Dice : IDice
{
   private readonly IRng _rng;
   public Dice(IRng rng) {
      _rng = rng;
   }

   public static IDice Simple { get; } = new Dice(SimpleRng.Instance);
   public static IDice Crypto { get; } = new Dice(CryptoRng.Instance);
   
   public int NextD4() => _rng.Next(1, 5);
   public int NextD6() => _rng.Next(1, 7);
   public int NextD8() => _rng.Next(1, 9);
   public int NextD10() => _rng.Next(1, 11);
   public int NextD100() => _rng.Next(1, 101);
}
