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
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            return items[0];
        }

        [Test]
        public void SellInAndQualityLower()
        {
            Item item = CreateItemAndUpdateIt("foo", 15, 25);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);
        }

        [Test]
        public void QualityLowerTwice()
        {
            Item item = CreateItemAndUpdateIt("foo", 0, 25);
            Assert.AreEqual(23, item.Quality);
        }

        [Test]
        public void QualityNotNegative()
        {
            Item item = CreateItemAndUpdateIt("foo", 15, 0);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void QualityIncreaseAged()
        {
            Item item = CreateItemAndUpdateIt("Aged Brie", 15, 25);
            Assert.AreEqual(26, item.Quality);
        }

        [Test]
        public void QualityNotMoreThan50()
        {
            Item item = CreateItemAndUpdateIt("Aged Brie", 15, 50);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void QualityNeverDecrease()
        {
            Item item = CreateItemAndUpdateIt("Sulfuras, Hand of Ragnaros", 15, 80);
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void QualityIncreaseBackstage()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 15, 25);
            Assert.AreEqual(26, item.Quality);
        }

        [Test]
        public void QualityIncreaseBy2WhenSellIn10orLess()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 10, 25);
            Assert.AreEqual(27, item.Quality);
        }


        [Test]
        public void QualityIncreaseBy3WhenSellIn5orLess()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 5, 25);
            Assert.AreEqual(28, item.Quality);
        }

        [Test]
        public void QualityDropTo0AfterConcert()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 0, 25);
            Assert.AreEqual(0, item.Quality);
        }

    }

}
