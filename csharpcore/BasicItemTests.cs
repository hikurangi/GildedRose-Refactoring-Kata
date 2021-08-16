using Xunit;
using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;

namespace csharpcore
{
    public class BasicItemTests
    {
        [Property]
        public Property WhenADayPasses_TheSellInIsDecrementedByOne(int sellIn) =>
            (WhenADayPasses(sellIn).SellIn == sellIn - 1).ToProperty();

        [Property]
        public Property WhenSellInHasNotPassed_AndQualityIsAboveZero_TheQualityIsDecrementedByOne(int sellIn,
            int quality) =>
            (WhenADayPasses(sellIn, quality).Quality == quality - 1).ToProperty().When(sellIn > 0 && quality > 0);

        [Property]
        public Property
            WhenSellInHasPassed_AndQualityIsTwoOrMore_TheQualityIsDecrementedByTwo(int sellIn, int quality) =>
            (WhenADayPasses(sellIn, quality).Quality == quality - 2).ToProperty().When(sellIn < 1 && quality >= 2);

        [Property]
        public Property WhenSellInHasPassed_AndQualityIsOne_TheQualityIsDecrementedToZero(int sellIn) =>
            (WhenADayPasses(sellIn, 1).Quality == 0).ToProperty().When(sellIn <= 0);

        [Property]
        public Property WhenQualityIsOne_TheQualityIsAlwaysDecrementedToZero(int sellIn) =>
            (WhenADayPasses(sellIn, 1).Quality == 0).ToProperty();

        [Property]
        public Property QualityCannotGoBelowZero(int sellIn) =>
            (WhenADayPasses(sellIn, 0).Quality == 0).ToProperty();

        // TODO: currently a basic item can be instantiated and used with a quality higher than 50.

        private Item WhenADayPasses(int sellIn = 5, int quality = 5)
        {
            var item = new Item
            {
                Name = "foo",
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