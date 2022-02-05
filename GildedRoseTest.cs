using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private Item CreateItemAndUpdateIt(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality} };
            GildedRoseQualityChange app = new GildedRoseQualityChange(items);
            app.UpdateQuality();
            return items[0];
        }

        [Test]
        public void SellInAndQualityLower()
        {
            Item item = CreateItemAndUpdateIt("test", 15, 25);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);
        }

        [Test]
        public void QualityLowerTwiceWhenSellIn0()
        {
            Item item = CreateItemAndUpdateIt("test", 0, 25);
            Assert.AreEqual(23, item.Quality);
        }

        [Test]
        public void QualityNotNegative()
        {
            Item item = CreateItemAndUpdateIt("test", -1, 0);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void QualityIncreaseAged()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.AgedBrie, 15, 25);
            Assert.AreEqual(26, item.Quality);
        }

        [Test]
        public void QualityNotMoreThan50()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.AgedBrie, 15, GildedRoseQualityChange.MaxQuality);
            Assert.AreEqual(GildedRoseQualityChange.MaxQuality, item.Quality);
        }

        [Test]
        public void SulfurasQualityNeverDecrease()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.Sulfuras, 15, 80);
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void QualityIncreaseBackstage()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.BackstagePasses, 15, 25);
            Assert.AreEqual(26, item.Quality);
        }

        [Test]
        public void QualityIncreaseBy2WhenSellIn10orLess()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.BackstagePasses, 10, 25);
            Assert.AreEqual(27, item.Quality);
        }


        [Test]
        public void QualityIncreaseBy3WhenSellIn5orLess()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.BackstagePasses, 5, 25);
            Assert.AreEqual(28, item.Quality);
        }

        [Test]
        public void QualityDropTo0AfterConcert()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.BackstagePasses, 0, 25);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void ConjuredQualityLowerTwice()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.Conjured, 15, 25);
            Assert.AreEqual(23, item.Quality);
        }

        [Test]
        public void ConjuredQualityLowerTwiceAfterSellIn()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.Conjured, 0, 25);
            Assert.AreEqual(21, item.Quality);
        }

        [Test]
        public void ConjuredQualityNotNegative()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.Conjured, 10, 0);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void ConjuredQualityNotNegativeAfterSellIn()
        {
            Item item = CreateItemAndUpdateIt(GildedRoseQualityChange.Conjured, 0, 0);
            Assert.AreEqual(0, item.Quality);
        }

    }

}
