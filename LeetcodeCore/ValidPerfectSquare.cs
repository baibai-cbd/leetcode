using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class ValidPerfectSquare
    {
        // 367. Valid Perfect Square
        // Not the best solution, need to be improved
        public bool IsPerfectSquare(int num)
        {
            if (num == 1)
                return true;

            var lastDigit = num % 10;
            if (lastDigit == 2 || lastDigit == 3 || lastDigit == 7 || lastDigit == 8)
                return false;

            for (int i = 1; i <= num/2; i++)
            {
                var square = i * i;
                if (square == num)
                    return true;
                if (square > num)
                    return false;
            }
            return false;
        }
    }
}
