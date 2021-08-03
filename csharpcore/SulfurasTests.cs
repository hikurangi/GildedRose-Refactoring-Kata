using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class SulfurasTests
    {
        [Fact]
        public void SulfurasNeverDipsBelow80Quality()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80};
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();
            
            Assert.Equal(80, item.Quality); 
        }
    }
}