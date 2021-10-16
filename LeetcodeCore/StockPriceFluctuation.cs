using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // 2034. Stock Price Fluctuation
    // Using SortedDictionary doesn't give good result, because of too many operations with O(logN) cost.
    // By separating into a SortedSet and a Dictionary, only when removing or adding unique prices we need O(logN) op to search the SortedSet.
    public class StockPrice
    {
        private readonly Dictionary<int, int> _priceTimeDict;   // (timestamp, price)
        private readonly Dictionary<int, int> _priceCountDict;  // (price, count)
        private readonly SortedSet<int> _priceSet;  // unique prices with ordering
        private int _lastTimestamp;  // latest timestamp

        public StockPrice()
        {
            _priceTimeDict = new Dictionary<int, int>();
            _priceCountDict = new Dictionary<int, int>();
            _priceSet = new SortedSet<int>();
            _lastTimestamp = -1;
        }

        public void Update(int timestamp, int price)
        {
            if (_priceTimeDict.ContainsKey(timestamp))
            {
                // get old price
                var oldPrice = _priceTimeDict[timestamp];

                if (oldPrice != price)
                {
                    // update priceSet
                    _priceTimeDict[timestamp] = price;

                    // remove old price count
                    var oldCount = _priceCountDict[oldPrice];
                    if (oldCount == 1)
                    {
                        _priceCountDict.Remove(oldPrice);
                        _priceSet.Remove(oldPrice);
                    }
                    else
                    {
                        _priceCountDict[oldPrice]--;
                    }

                    // add new price count
                    if (_priceCountDict.ContainsKey(price))
                    {
                        _priceCountDict[price]++;
                    }
                    else
                    {
                        _priceCountDict.Add(price, 1);
                        _priceSet.Add(price);
                    }
                }
            }
            else
            {
                _priceTimeDict.Add(timestamp, price);
                _lastTimestamp = Math.Max(_lastTimestamp, timestamp);
                if (_priceCountDict.ContainsKey(price))
                {
                    _priceCountDict[price]++;
                }
                else
                {
                    _priceCountDict.Add(price, 1);
                    _priceSet.Add(price);
                }
            }
        }

        public int Current()
        {
            return _priceTimeDict[_lastTimestamp];
        }

        public int Maximum()
        {
            return _priceSet.Max;
        }

        public int Minimum()
        {
            return _priceSet.Min;
        }
    }

    /**
     * Your StockPrice object will be instantiated and called as such:
     * StockPrice obj = new StockPrice();
     * obj.Update(timestamp,price);
     * int param_2 = obj.Current();
     * int param_3 = obj.Maximum();
     * int param_4 = obj.Minimum();
     */
}
