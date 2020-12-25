using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FiveStarSellers
    {
        public int NumOfReviewsToFiveStar(int[][] productRatings, int threshold)
        {
            var deltaPQ = new SortedSet<Tuple<int, double>>(Comparer<Tuple<int, double>>.Create((a, b) => b.Item2.CompareTo(a.Item2)));
            var currSum = 0.0;
            for (int i = 0; i < productRatings.Length; i++)
            {
                currSum += productRatings[i][0] / (double)productRatings[i][1];
            }
            var currRating = currSum * (double)100;
            var totalDelta = (double)threshold * productRatings.Length - currRating; // times ratings.Length so that it's normalized to a simple sum
            var currDelta = 0.0;
            var newReviewsCount = 0;
            for (int i = 0; i < productRatings.Length; i++)
            {
                deltaPQ.Add(new Tuple<int, double>(i, CalculateDeltaPercentage(productRatings[i])));
            }

            while (currDelta < totalDelta)
            {
                var newReview = deltaPQ.Min; // Min as defined by comparer means the frontest element, in this case I put the biggest delta as frontest, thus it's Min
                currDelta += newReview.Item2;
                newReviewsCount++;
                productRatings[newReview.Item1][0]++;
                productRatings[newReview.Item1][1]++;
                // whether the remove/add in SortedSet have good time complexity is questionable
                deltaPQ.Remove(newReview);
                deltaPQ.Add(new Tuple<int, double>(newReview.Item1, CalculateDeltaPercentage(productRatings[newReview.Item1])));
            }

            return newReviewsCount;
        }

        private double CalculateDeltaPercentage(int[] ratings)
        {
            return ((ratings[0] + 1) / (double)(ratings[1] + 1) - ratings[0] / (double)ratings[1]) * 100;
        }
    }
}
