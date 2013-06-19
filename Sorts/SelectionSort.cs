using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class SelectionSort : SortBase
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
			for (int j = 0; j < data.Length - 1; j++)
			{
				int min = j;
				for (int i = j + 1; i < data.Length; i++)
				{
					if (!Compare(data, i, min))
						min = i;
				}

				if (min != j)
					Swap(data, j, min);
			}

			ShowArray(data);
			Assert.That(data, Is.Ordered);
		}
	}
}