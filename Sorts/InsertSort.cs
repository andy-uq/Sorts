using NUnit.Framework;

namespace Sorts
{
	[TestFixture]
	public class InsertSort : SortBase
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
		public void Sort()
		{
			int[] data = {4, 3, 2, 1 };

			Sort(data, offset: 1);
			Assert.That(data, Is.EqualTo(new[] {  3, 4, 2, 1 }), DataString(data));

			Sort(data, offset: 2);
			Assert.That(data, Is.EqualTo(new[] {  2, 3, 4, 1 }), DataString(data));

			Sort(data, offset: 3);
			Assert.That(data, Is.EqualTo(new[] {  1, 2, 3, 4 }), DataString(data));
		}

		private void Sort(int[] data)
		{
			for ( var i = 1; i < data.Length; i++ )
			{
				Sort(data, i);
			}
		}

		private void Sort(int[] data, int offset)
		{
			int value = data[offset];
			while (offset > 0 && Compare(data[offset - 1], value))
			{
				Assign(data, offset, data[offset - 1]);
				offset--;
			}

			Assign(data, offset, value);
		}
	}
}