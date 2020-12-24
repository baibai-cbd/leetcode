using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AmznFulfillmentBuilder
    {
        public int FulfillmentBuilder(int[] items)
        {
            // generally just a greedy solution
            if (items == null || items.Length == 0)
                return 0;
            if (items.Length == 1)
                return items[0];

            var result = 0;
            Array.Sort(items); // no easy way to sort an IList
            var itemList = new List<int>(items); // no easy way modify size of an array

            while (itemList.Count > 1)
            {
                var combinedItem = itemList[0] + itemList[1];
                result += combinedItem;
                itemList.RemoveRange(0,2);
                var newIndex = itemList.BinarySearch(combinedItem); // binary search and insert is better than insert and sort every time
                if (newIndex >= 0)
                {
                    itemList.Insert(newIndex, combinedItem);
                }
                else
                {
                    itemList.Insert((newIndex + 1) * -1, combinedItem);
                }
            }

            return result;
        }
    }
}
