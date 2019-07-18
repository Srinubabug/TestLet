using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlet.DAL
{
    static class ExtensionRandomize
    {
        public static List<Item> RandomizeItems(this List<Item> items)
        {
            for (int i = items.Count - 1; i > 0; i--)
            {
                Swap(items, i, StaticRandom.Instance.Next(i + 1));
            }
            return items;
        }

        private static void Swap(List<Item> items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

    }
}
