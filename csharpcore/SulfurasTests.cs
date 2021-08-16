using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;

namespace csharpcore
{
    public class SulfurasTests
    {
        [Property]
        public Property WhenADayPasses_QualityStaysAtEighty(int sellIn) =>
            (WhenADayPasses(sellIn).Quality == 80).ToProperty();

        [Property]
        public Property WhenADayPasses_SellInDoesNotChange(int sellIn) =>
            (WhenADayPasses(sellIn).SellIn == sellIn).ToProperty();

        private Item WhenADayPasses(int sellIn = 5, int quality = 80)
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = sellIn,
                Quality = quality
            };
            var items = new List<Item> {item};
            var app = new GildedRose(items);

            app.UpdateQuality();

            return item;
        }
    }
}