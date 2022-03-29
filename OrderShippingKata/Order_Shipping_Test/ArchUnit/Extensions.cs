using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using OrderShipping.UseCase;

namespace OrderShippingTest.ArchUnit
{
    internal static class Extensions
    {
        private static readonly Architecture Architecture =
    new ArchLoader()
        .LoadAssemblies(typeof(OrderShipmentUseCase).Assembly)
        .Build();
        public static void Check(this IArchRule rule) => rule.Check(Architecture);
    }
}
