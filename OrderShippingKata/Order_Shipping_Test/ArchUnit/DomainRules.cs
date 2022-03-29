using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace OrderShippingTest.ArchUnit
{
    public class DomainRules
    {
        [Fact]
        public void ClassesInDomainCanOnlyAccessClassesInDomainItself() =>
            Classes().That()
                .ResideInNamespace("Domain")
                .Should()
                .OnlyDependOnTypesThat()
                .ResideInNamespace("Domain")
                .Check();
    }
}
