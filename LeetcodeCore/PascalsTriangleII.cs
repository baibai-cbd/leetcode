using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PascalsTriangleII
    {
		// 119. Pascal's Triangle II
		public IList<int> GetRow(int rowIndex)
		{
			var list = new List<int>();
			if (rowIndex < 0)
				return list;

			for (int i = 0; i < rowIndex + 1; i++)
			{
				list.Insert(0, 1);
				for (int j = 1; j < list.Count - 1; j++)
				{
					list[j] = list[j] + list[j + 1];
				}
			}
			return list;
		}
	}
}
