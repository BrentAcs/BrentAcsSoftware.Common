using BrentAcsSoftware.Common.Extensions;

namespace BrentAcsSoftware.Common.Tests.Extensions;

public class JsonCovertExtensionsTests
{
   public record TestPoco(string? Name, int Age)
   {
   }

   [Fact]
   public void AsJson_WillReturnNull_OnNullObject()
   {
      TestPoco? poco = null;

      var json = poco.AsJson();

      json.Should().BeNull();
   }

   [Fact]
   public void AsJson_WillReturnString_OnNonNullObject()
   {
      var poco = new TestPoco("Brent", 42);

      var json = poco.AsJson();

      json.Should().NotBeEmpty();
   }

   [Fact]
   public void AsJsonIndented_WillReturnNull_OnNullObject()
   {
      TestPoco? poco = null;

      var json = poco.AsJsonIndented();

      json.Should().BeNull();
   }
}
