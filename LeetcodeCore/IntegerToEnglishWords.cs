using System;
using System.Text;

namespace LeetcodeCore
{
    public class IntegerToEnglishWords
    {
        // 273. Integer to English Words
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            var sb = new StringBuilder();
            var factor = 1000000000;

            var b = num / factor;
            var bmod = num % factor;
            if (b != 0)
            {
                MapToStringUnder1000(b, sb);
                sb.Append("Billion ");
            }
            factor = 1000000;
            var m = bmod / factor;
            var mmod = bmod % factor;
            if (m != 0)
            {
                MapToStringUnder1000(m, sb);
                sb.Append("Million ");
            }
            factor = 1000;
            var k = mmod / factor;
            var kmod = mmod % factor;
            if (k != 0)
            {
                MapToStringUnder1000(k, sb);
                sb.Append("Thousand ");
            }
            if (kmod != 0)
            {
                MapToStringUnder1000(kmod, sb);
            }

            return sb.ToString().Trim();
        }

        private void MapToStringUnder1000(int i, StringBuilder sb)
        {
            var h = i / 100;
            if (h != 0)
            {
                sb.Append(MapToDistinctWords(h) + " Hundred ");
            }
            var hmod = i % 100;
            var t = hmod / 10;
            if (t >= 2)
            {
                sb.Append(MapToDistinctWords(t * 10) + " ");
                var o = hmod % 10;
                if (o != 0)
                {
                    sb.Append(MapToDistinctWords(o) + " ");
                }
            }
            else if (t == 1)
            {
                sb.Append(MapToDistinctWords(hmod) + " ");
            }
            else
            {
                var o = hmod % 10;
                if (o != 0)
                {
                    sb.Append(MapToDistinctWords(o) + " ");
                }
            }
        }

        private string MapToDistinctWords(int x)
        {
            switch (x)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Eleven";
                case 12:
                    return "Twelve";
                case 13:
                    return "Thirteen";
                case 14:
                    return "Fourteen";
                case 15:
                    return "Fifteen";
                case 16:
                    return "Sixteen";
                case 17:
                    return "Seventeen";
                case 18:
                    return "Eighteen";
                case 19:
                    return "Nineteen";
                case 20:
                    return "Twenty";
                case 30:
                    return "Thirty";
                case 40:
                    return "Forty";
                case 50:
                    return "Fifty";
                case 60:
                    return "Sixty";
                case 70:
                    return "Seventy";
                case 80:
                    return "Eighty";
                case 90:
                    return "Ninety";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
