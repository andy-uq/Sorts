using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class HeapSort : SortBase
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

		[Test]
		public void Heapify()
		{
			int[] data = new[] {1, 2, 3, 4, 5, 6};
			Heapify(data);
		}

		[Test]
		public void SiftDown()
		{
			int[] data = new[] {1, 2, 3, 4, 5, 6 };
			SiftDown(data, 3, 5);

			ShowArray(data);
		}

		private void Sort(int[] data)
		{
			Heapify(data);

			int end = data.Length - 1;
			while (end > 0)
			{
				Swap(data, 0, end);
				end--;
				SiftDown(data, start: 0, end: end);
			}

			ShowArray(data);
			Assert.That(data, Is.Ordered);
		}

		private void Heapify(int[] data)
		{
			int count = data.Length - 1;
			int start = count/2;

			while (start >= 0)
			{
				SiftDown(data, start, count);
				start--;
			}

			ShowArray(data, prefix: "H");
		}

		private void SiftDown(int[] a, int start, int end)
		{
			int root = start;

			while ((root * 2 + 1) <= end)
			{
				int swap = root;
				int left = root*2 + 1;
				int right = left + 1;

				// (check if root is smaller than left child)
				if (Compare(a, left, swap))
				{
					swap = left;
				}

				//(check if right child exists, and if it's bigger than what we're currently swapping with)
				if ( right <= end && Compare(a, right, swap) )
				{
					swap = right;
				}

				if (swap == root)
				{
					return;
				}
				
				Swap(a, root, swap);
				root = swap;
			}
		}
	}
}