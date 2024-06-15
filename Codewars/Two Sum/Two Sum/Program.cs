public class Kata
{
	public static int[] TwoSum(int[] numbers, int target)
	{
		for (int i = 0; i < numbers.Length; i++)
		{
			for (int j = 0; j < numbers.Length; j++)
			{
				if (numbers[i] + numbers[j] == target && i != j)
				{
					return new int[] { j, i };
				}
			}
		}

		return new int[0];
	}
}

public static class Program
{
	public static void Main()
	{
		int[] arr = Kata.TwoSum(new[] { 1, 2, 3 }, 4); // [0, 2]

		Display(arr);

		arr = Kata.TwoSum(new[] { 1234, 5678, 9012 }, 14690); // [1, 2]

		Display(arr);

		arr = Kata.TwoSum(new[] { 2, 2, 3 }, 4); // [1, 0]

		Display(arr);
	}

	private static void Display(int[] numbers)
	{
		foreach (int i in numbers)
		{
			Console.Write(i + " ");
		}
		Console.WriteLine();
	}
}