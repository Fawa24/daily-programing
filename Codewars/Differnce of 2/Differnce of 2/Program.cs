using System;
using System.Collections.Generic;

public class Kata
{
	public static (int, int)[] TwosDifference(int[] array)
	{
		Array.Sort(array);
		List<(int, int)> list = new List<(int, int)>();

		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i; j < array.Length; j++)
			{
				if (Math.Abs(array[i] - array[j]) == 2)
				{
					list.Add((array[i], array[j]));
				}
			}
		}

		(int, int)[] result = list.ToArray();

		return result;
	}
}

public static class Program
{
	public static void Main(string[] args)
	{

	}
}