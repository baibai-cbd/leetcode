using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SatisfiabilityOfEqualityEquations
    {
        // 990. Satisfiability of Equality Equations
        // This solution is super easy and mathmatically brilliant with the usage of Union-Find
        public bool EquationsPossible(string[] equations)
        {
            var uf = new UnionFind(26);

            foreach (var eq in equations)
            {
                if (eq.Substring(1,2) == "==")
                {
                    uf.Union(eq[0] - 'a', eq[3] - 'a');
                }
            }
            foreach (var eq in equations)
            {
                if (eq.Substring(1, 2) == "!=")
                {
                    if (uf.Connected(eq[0] - 'a', eq[3] - 'a'))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
