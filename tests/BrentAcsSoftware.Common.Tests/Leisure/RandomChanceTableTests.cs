using BrentAcsSoftware.Common.Leisure.Utilities;

namespace BrentAcsSoftware.Common.Tests.Leisure;

public class RandomChanceTableTests
{
   public class TestRandomChanceTable : RandomChanceTable<string>
   {
      protected override void BuildTable()
      {
         AddEntry(10, "Entry 1");
         AddEntry(25, "Entry 2");
         AddEntry(25, "Entry 3");
         AddEntry(null, "Entry 4");
      }
   }

   public class MultipleNullChanceTestRandomChanceTable : RandomChanceTable<string>
   {
      protected override void BuildTable()
      {
         AddEntry(10, "Entry 1");
         AddEntry(25, "Entry 2");
         AddEntry(null, "Entry 3");
         AddEntry(null, "Entry 4");
      }
   }

   [Theory]
   [InlineData(9, "Entry 1")]
   [InlineData(34, "Entry 2")]
   [InlineData(35, "Entry 3")]
   [InlineData(59, "Entry 3")]
   [InlineData(60, "Entry 4")]
   public void GetByChance_TestCases(double chance, string expectedName)
   {
      var sut = new TestRandomChanceTable();

      var result = sut.GetByChance(chance);

      result.Should().Be(expectedName);
   }

   [Fact]
   public void GetByChance_WillThrow_WhenEntriesContainsMultipleNullChances()
   {
      var sut = new MultipleNullChanceTestRandomChanceTable();

      var action = () => { sut.GetByChance(10); };

      action.Should().Throw<Exception>();
   }
}
