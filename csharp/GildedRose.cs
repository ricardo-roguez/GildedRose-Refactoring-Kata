using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }

                        item.SellIn -= 1;

                        if (item.SellIn < 0 && item.Quality < 50)
                        {
                            item.Quality += 1;
                        }

                        break;
                    }
                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;

                            if (item.SellIn < 11 && item.Quality < 50)
                            {
                                item.Quality += 1;
                            }

                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        item.SellIn -= 1;

                        if (item.SellIn < 0)
                        {
                            item.Quality -= item.Quality;
                        }

                        break;
                    }
                    default:
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
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

                        break;
                    }
                }
            }
        }
    }
}