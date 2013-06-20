using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace Sorts
{
	public abstract class SortBase
	{
		private int _compares;
		private int _swaps;
		private int _assigns;

		[SetUp]
		public void ResetCounters()
		{
			_compares = 0;
			_swaps = 0;
			_assigns = 0;
		}

		[TearDown]
		public void Report()
		{
			Console.WriteLine("Compares: {0:n0}", _compares);
			Console.WriteLine("Assigns: {0:n0}", _assigns);
			Console.WriteLine("Swaps: {0:n0}", _swaps);
		}

		protected void Swap(int[] data, int a, int b)
		{
			ShowArray(data, prefix:"X: ");

			var tmp = data[a];
			Assign(data, a, data[b]);
			Assign(data, b, tmp);
			_swaps++;
		}

		protected static void ShowArray(IEnumerable<int> data, string prefix = "")
		{
			if (string.IsNullOrEmpty(prefix))
				Console.WriteLine(DataString(data));
			
			Console.WriteLine(prefix + DataString(data));
		}

		protected static string DataString(IEnumerable<int> data)
		{
			return string.Join(", ", data.Select(x => x.ToString(CultureInfo.CurrentCulture)));
		}

		protected bool Compare(int[] data, int a, int b)
		{
			return Compare(data[a], data[b]);
		}

		protected bool Compare(int a, int b)
		{
			_compares++;
			return a > b;
		}

		protected void Assign(int[] data, int offset, int value)
		{
			_assigns++;
			data[offset] = value;
		}
	}
}