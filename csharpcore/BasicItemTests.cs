using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class BasicItemTests
    {
        [Fact]
        public void WhenQualityIsZero_AndADayPasses_TheQualityIsZero()
        {
            var item = new Item {Name = "foo", SellIn = 10, Quality = 0};
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }
        
        [Theory]
        [InlineData(1, 0)]
        [InlineData(int.MaxValue, int.MaxValue - 1)]
        [InlineData(0, -1)]
        [InlineData(int.MinValue + 1, int.MinValue)]
        public void WhenADayPasses_TheSellInValueIsDecremented(int initial, int expected)
        {
            var item = new Item {Name = "foo", SellIn = initial, Quality = 5};
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(expected, item.SellIn);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenTheSellInHasPassed_TheQualityDecreasesByTwo(int sellIn)
        {
            var item = new Item {Name = "foo", SellIn = sellIn, Quality = 10};
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void WhenSellInIsNegative_AndQualityIsOne_ThenQualityIsZero()
        {
            var item = new Item {Name = "foo", SellIn = -3, Quality = 1};
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }
    }
}