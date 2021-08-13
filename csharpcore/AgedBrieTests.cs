using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class AgedBrieTests
    {
        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(1)]
        public void WhenNotDueToBeSold_AndADayPasses_QualityIncreasesByOne(int sellIn)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = sellIn,
                Quality = 6
            };
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();
            
            Assert.Equal(7, item.Quality); 
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void WhenNotDueToBeSold_AndADayPasses_QualityIncreasesByTwo(int sellIn)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = sellIn,
                Quality = 6
            };
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();
            
            Assert.Equal(8, item.Quality); 
        }
    }
}