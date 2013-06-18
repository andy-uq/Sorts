using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class BubbleSort : SortBase
	{
		[Test]
		public void WorstCase()
		{
			Sort(new[] {9, 8, 7, 3, 2, 1});
		}

		[Test]
		public void BestCase()
		{
			Sort(new[] {1,2,3,7,8,9});
		}

		private void Sort(int[] data)
		{
			for (int i = 0; i < data.Length; i ++)
			{
				for (int k = i + 1; k < data.Length; k++)
				{
					if (Compare(data, i, k))
					{
						Swap(data, i, k);
					}
				}
			}

			ShowArray(data);
			Assert.That(data, Is.Ordered);
		}
	}
}
