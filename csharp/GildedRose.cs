using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                    {
                        AgedBrieCase(item);
                        break;
                    }
                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        BackstagePassesToCase(item);
                        break;
                    }
                    default:
                    {
                        DefaultCase(item);
                        break;
                    }
                }
            }
        }

        private static void AgedBrieCase(Item item)
        {
            if (QualityLessThanFifty(item))
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0 && QualityLessThanFifty(item))
            {
                item.Quality += 1;
            }
        }

        private static void BackstagePassesToCase(Item item)
        {
            if (QualityLessThanFifty(item))
            {
                item.Quality += 1;

                if (item.SellIn < 11 && QualityLessThanFifty(item))
                {
                    item.Quality += 1;
                }

                if (item.SellIn < 6 && QualityLessThanFifty(item))
                {
                    item.Quality += 1;
                }
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }

        private static void DefaultCase(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
        
        private static bool QualityLessThanFifty(Item item)
        {
            return item.Quality < 50;
        }
    }
}