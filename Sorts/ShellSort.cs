using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class ShellSort : SortBase
	{
		private int[] _gaps;

		[Test]
		public void WorstCase()
		{
			_gaps = new[] { 701, 301, 132, 57, 23, 10, 4, 1 };
			Sort(new[] { 9, 8, 7, 3, 2, 1 }, _gaps);
		}
		[Test]
		public void BestCase()
		{
			_gaps = new[] { 701, 301, 132, 57, 23, 10, 4, 1 };
			Sort(new[] { 1, 2, 3, 7, 8, 9 }, _gaps);
		}

		private void Sort(int[] data, int[] gaps)
		{
			foreach ( var g in gaps )
			{
				SortIteration(data, g);
			}

			Assert.That(data, Is.Ordered);
		}

		private void SortIteration(int[] data, int skip)
		{
			for (var j = skip; j < data.Length; j++)
			{
				var value = data[j];

				var k = j;
				while (k >= skip && Compare(data[k - skip], value))
				{
					data[k] = data[k - skip];
					k -= skip;
				}

				data[k] = value;
			}
		}
	}
}