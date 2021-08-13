using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class SulfurasTests
    {
        [Fact]
        public void WhenADayPasses_QualityStaysAtEighty()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 80
            };
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(80, item.Quality);
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenADayPasses_SellInDoesNotChange(int sellIn)
        {
	        var item = new Item
	        {
		        Name = "Sulfuras, Hand of Ragnaros",
		        SellIn = sellIn,
		        Quality = 80,
	        };
	        var items = new List<Item> { item };
	        var app = new GildedRose(items);

	        app.UpdateQuality();

	        Assert.Equal(sellIn, item.SellIn);
        }
    }
}