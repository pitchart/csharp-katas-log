using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> {new() {Name = "foo", SellIn = 0, Quality = 0}};
        var gildedRose = new GildedRose(Items);
        gildedRose.UpdateQuality();
        Assert.Equal("fixme", Items[0].Name);
    }
}