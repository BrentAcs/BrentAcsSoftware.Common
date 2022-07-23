using BrentAcsSoftware.Common.Extensions;

namespace BrentAcsSoftware.Common.Tests.Extensions;

public class IntExtensionsTests
{
   [Theory]
   [InlineData(0, true)]
   [InlineData(1, false)]
   [InlineData(2, true)]
   public void IsEven_Cases(int value, bool expected)
   {
      var result = value.IsEven();

      result.Should().Be(expected);
   }
   
   [Theory]
   [InlineData(0, false)]
   [InlineData(1, true)]
   [InlineData(2, false)]
   public void IsOdd_Cases(int value, bool expected)
   {
      var result = value.IsOdd();

      result.Should().Be(expected);
   }
   
   [Theory]
   [InlineData(-1, false)]
   [InlineData(0, false)]
   [InlineData(1, true)]
   public void IsPositive_Cases(int value, bool expected)
   {
      var result = value.IsPositive();

      result.Should().Be(expected);
   }
   
   [Theory]
   [InlineData(-1, true)]
   [InlineData(0, false)]
   [InlineData(1, false)]
   public void IsNegative_Cases(int value, bool expected)
   {
      var result = value.IsNegative();

      result.Should().Be(expected);
   }
}
