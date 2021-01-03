using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class TransactionLogs
    {
        // should be a easy problem
        public string[] ProcessLogFile(string[] logs, int threshold)
        {
            var dict = new Dictionary<string, int>();
            foreach (var s in logs)
            {
                var arr = s.Split(" ");
                if (dict.ContainsKey(arr[0]))
                    dict[arr[0]]++;
                else
                    dict.Add(arr[0], 1);
                if (dict.ContainsKey(arr[1]))
                    dict[arr[1]]++;
                else
                    dict.Add(arr[1], 1);
                if (arr[0] == arr[1]) // if transaction goes to oneself, count as one
                    dict[arr[0]]--;
            }

            var resultArr = dict.Where(kv => kv.Value >= threshold).Select(kv => kv.Key).OrderBy(s => int.Parse(s)).ToArray();
            return resultArr;
        }
    }
}
