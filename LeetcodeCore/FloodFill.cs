using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class FloodFillSolution
    {
        // 733. Flood Fill
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var oldColor = image[sr][sc];

            if (oldColor == newColor)
                return image;

            FillHelper(image, sr, sc, newColor, oldColor);
            return image;
        }

        private void FillHelper(int[][] image, int sr, int sc, int newColor, int oldColor)
        {
            if (image[sr][sc] != oldColor)
                return;

            image[sr][sc] = newColor;

            if (sr + 1 < image.Length)
                FillHelper(image, sr + 1, sc, newColor, oldColor);
            if (sr - 1 >= 0)
                FillHelper(image, sr - 1, sc, newColor, oldColor);
            if (sc + 1 < image[sr].Length)
                FillHelper(image, sr, sc + 1, newColor, oldColor);
            if (sc - 1 >= 0)
                FillHelper(image, sr, sc - 1, newColor, oldColor);
        }
    }
}
