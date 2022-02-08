using System;
using System.Collections.Generic;
using System.Linq;

namespace Approval.Tests;

public static class CollectionExtensions
{
    public static IEnumerable<Tuple<TEnum1, TEnum2>> CombineEnumValues<TEnum1, TEnum2>()
        where TEnum1 : struct, Enum where TEnum2 : struct, Enum =>
        from a in Enum.GetValues<TEnum1>()
        from b in Enum.GetValues<TEnum2>()
        select new Tuple<TEnum1, TEnum2>(a, b);

    public static IEnumerable<Tuple<T1, T2>> Combine<T1, T2>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second) =>
        from a in first
        from b in second
        select new Tuple<T1, T2>(a, b);
}
