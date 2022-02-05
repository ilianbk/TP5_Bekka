using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class GildedRoseQualityChange
    {
        public IList<Item> Items;

        public GildedRoseQualityChange(IList<Item> items)
        {
            Items = items;
        }

        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured Mana Cake";
        public const int MaxQuality = 50;
        public const int Limit = 11;
        public const int Limit2 = 6;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                
                ActionOnNormalItem(item);

                ActionOnAgedBrieItem(item);
             
                ActionOnBackstagePassesItem(item);
               
                ActionOnSulfurasItem(item);

                ActionOnConjuredItem(item);              
            }
        }

        private void ActionOnConjuredItem(Item item)
        {
            if (ItemIsConjured(item))
            {
                item.SellIn --;
                item.Quality = item.Quality - 2;

                if (item.SellIn <= 0)
                {
                    item.Quality = item.Quality - 2;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }

        }

        private static void ActionOnSulfurasItem(Item item)
        {
            if (ItemIsSulfuras(item))
            {
                item.SellIn--;
            }
        }

        private static void ActionOnBackstagePassesItem(Item item)
        {
            if (ItemIsBackstagePasses(item))
            {
                item.SellIn--;
                item.Quality++;

                if (item.SellIn < Limit)
                {
                    item.Quality++;
                }

                if (item.SellIn < Limit2)
                {
                    item.Quality++;
                }

                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }

                if (item.Quality > MaxQuality)
                {
                    item.Quality = MaxQuality;
                }
            }
        }

        private static void ActionOnAgedBrieItem(Item item)
        {
            if (ItemIsAgedBrie(item))
            {
                item.SellIn--;
                item.Quality++;

                if (item.SellIn <= 0)
                {
                    item.Quality++;
                }

                if (item.Quality > MaxQuality)
                {
                    item.Quality = MaxQuality;
                }
            }
        }

        private static void ActionOnNormalItem(Item item)
        {
            if (ItemIsNormal(item)) 
            {
                item.SellIn --;
                item.Quality --;

                if (item.SellIn <= 0)
                {
                    item.Quality--;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }

        private static bool ItemIsNormal(Item item)
        {
           return !(ItemIsAgedBrie(item) || ItemIsBackstagePasses(item) || ItemIsSulfuras(item) || ItemIsConjured(item));
        }

        private static bool ItemIsSulfuras(Item item)
        {
            return item.Name == Sulfuras;
        }

        private static bool ItemIsBackstagePasses(Item item)
        {
            return item.Name == BackstagePasses;
        }

        private static bool ItemIsAgedBrie(Item item)
        {
            return item.Name == AgedBrie;
        }

        private static bool ItemIsConjured(Item item)
        {
            return item.Name == Conjured;
        }
    }
}
