using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class FindTheTownJudge
    {
        // 997. Find the Town Judge
        // this is not a good solution, graph will be better
        public int FindJudge(int N, int[][] trust)
        {
            var trustLists = new TrustNode[N+1];
            for (int i = 0; i < trustLists.Length; i++)
                trustLists[i] = new TrustNode(i);
            foreach (var item in trust)
            {
                trustLists[item[0]].OutgoingTrustCount++;
                trustLists[item[1]].IncomingTrustCount++;
            }
            var judgeCandidates = trustLists.Where(tn => tn.Self != 0 && tn.IncomingTrustCount == N - 1 && tn.OutgoingTrustCount == 0);
            if (judgeCandidates.Count() == 1)
            {
                return judgeCandidates.First().Self;
            }
            return -1;
        }

        public class TrustNode
        {
            public readonly int Self;
            public int IncomingTrustCount;
            public int OutgoingTrustCount;

            public TrustNode(int self)
            {
                Self = self;
                IncomingTrustCount = 0;
                OutgoingTrustCount = 0;
            }
        }
    }
}
