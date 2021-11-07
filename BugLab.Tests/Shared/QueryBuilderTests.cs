using BugLab.Shared.Helpers.HttpClientHelpers;
using FluentAssertions;
using Xunit;

namespace BugLab.Tests.Shared
{
    public class QueryBuilderTests
    {
        [Fact]
        public void WithParam_EscapesValues_WithPercentageSign_In_Sentence()
        {
            var hello = "hello";
            var world = "world";

            var result = QueryBuilder.Use("api")
                .WithParam("sentence", $"{hello} {world}")
                .Build();

            result.Should().Contain("%");
            var splittedResult = result.Split('%');
            splittedResult[^1].Should().ContainAll(world, "20");
            splittedResult[^2].Should().Contain(hello);
        }
    }
}
