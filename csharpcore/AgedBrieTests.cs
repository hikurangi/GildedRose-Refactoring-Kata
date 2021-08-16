using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;

namespace csharpcore
{
    public class AgedBrieTests
    {
        [Property]
        public Property
            WhenDueToBeSold_AndADayPasses_QualityIncreasesByOne_UpToAMaximumOfFifty(int sellIn, int quality) =>
            (WhenADayPasses(sellIn, quality).Quality == quality + 1)
            .ToProperty().When(sellIn > 0 && quality <= 49); // actually tolerates 51

        [Property]
        public Property WhenNotDueToBeSold_AndADayPasses_QualityIncreasesByTwo_UpToAMaximumOfFifty(int sellIn,
            int quality) =>
            (WhenADayPasses(sellIn, quality).Quality == quality + 2).ToProperty()
            .When(sellIn <= 0 && quality <= 48); // actually tolerates 52

        // [Property]
        // public Property WhenNotDueToBeSold_QualityCannotIncreaseBeyondFifty(int sellIn, int quality) =>
        //     (WhenADayPasses(sellIn, quality).Quality <= 50).ToProperty().When(sellIn <= 0 && quality <= 48);
        //
        // [Property]
        // public Property WhenDueToBeSold_QualityCannotIncreaseBeyondFifty(int sellIn, int quality) =>
        //     (WhenADayPasses(sellIn, quality).Quality <= 50).ToProperty().When(sellIn > 0 && quality <= 49);

        private Item WhenADayPasses(int sellIn = 5, int quality = 5)
        {
            var item = new Item
            {
                Name = "Aged Brie",
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