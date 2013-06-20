using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class MergeSort : SortBase
	{
		[Test]
		public void WorstCase()
		{
			var result = Sort(new[] { 9, 8, 7, 3, 2, 1 });
			Assert.That(result, Is.Ordered);
		}

		[Test]
		public void BestCase()
		{
			var result = Sort(new[] { 1, 2, 3, 7, 8, 9 });
			Assert.That(result, Is.Ordered);
		}

		
		public IEnumerable<int> Sort(int[] data)
		{
			if ( data.Length <= 1 )
				return data;

			int middle = data.Length/2;
			var left = Split(data, 0, middle).ToArray();
			var right = Split(data, middle, data.Length).ToArray();

			return Merge(Sort(left), Sort(right));
		}

		[Test]
		public void MergeTest()
		{
			int[] left = new[] {1, 3, 5, 7}, right = {2, 4, 6, 8};

			var result = Merge(left, right);

			ShowArray(result);
			Assert.That(result, Is.Ordered);
			Assert.That(result, Is.EquivalentTo(Enumerable.Range(1, 8)));
		}

		[TestCase(8,4,4)]
		[TestCase(9,4,5)]
		[TestCase(1,0,1)]
		public void SplitTest(int length, int a, int b)
		{
			var data = Enumerable.Range(1, length).ToArray();
			int middle = data.Length/2;
			var left = Split(data, 0, middle).ToArray();
			var right = Split(data, middle, data.Length).ToArray();

			Assert.That(left.Count(), Is.EqualTo(a));
			Assert.That(right.Count(), Is.EqualTo(b));

			Assert.That(Merge(left, right), Is.EqualTo(data));
		}

		private IEnumerable<int> Split(int[] data, int start, int end)
		{
			return data.Skip(start).Take(end - start);
		}

		private IEnumerable<int> Merge(IEnumerable<int> a, IEnumerable<int> b)
		{
			var left = a.GetEnumerator();
			var right = b.GetEnumerator();

			bool rightHasData = right.MoveNext();

			while (left.MoveNext())
			{
				while (rightHasData && Compare(left.Current, right.Current))
				{
					yield return right.Current;
					rightHasData = right.MoveNext();
				}

				yield return left.Current;
			}

			while (rightHasData)
			{
				yield return right.Current;
				rightHasData = right.MoveNext();
			}
		}
	}
}