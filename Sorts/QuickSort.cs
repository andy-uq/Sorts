using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class QuickSort : SortBase
	{
		[Test]
		public void WorstCase()
		{
			Sort(new[] { 9, 8, 7, 3, 2, 1 });
		}

		[Test]
		public void BestCase()
		{
			Sort(new[] { 1, 2, 3, 7, 8, 9 });
		}

		private void Sort(int[] data)
		{
			Sort(data, 0, data.Length - 1);

			ShowArray(data);
			Assert.That(data, Is.Ordered);
		}

		private void Sort(int[] data, int left, int right)
		{
			if (left < right)
			{
				var pivotIndex = Partition(data, left, right, (left+right)/2);
				Sort(data, left, pivotIndex - 1);
				Sort(data, pivotIndex + 1, right);
			}
		}

		private int Partition(int[] data, int left, int right, int pivotIndex)
		{
			var pivotValue = data[pivotIndex];
			Swap(data, pivotIndex, right);
			var index = left;
			for ( int i = left; i <= right - 1; i++ )
			{
				if ( !Compare(data[i], pivotValue) )
				{
					Swap(data, i, index);
					index++;
				}
			}

			Swap(data, index, right);
			return index;
		}
	}
}