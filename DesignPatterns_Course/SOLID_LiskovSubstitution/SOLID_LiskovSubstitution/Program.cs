using static System.Console;

namespace DesignPatterns
{
	public class Rectangle
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle()
		{

		}

		public Rectangle(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public override string ToString()
		{
			return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
		}
	}

	public class Square : Rectangle
	{
		public new int Width
		{
			set
			{
				base.Width = base.Height = value;
			}
		}

		public new int Height
		{
			set
			{
				base.Height = base.Width = value;
			}
		}
	}

	public static class Program
	{
		public static void Main(string[] args)
		{
			Rectangle rc = new Rectangle(2, 3);

			WriteLine($"{rc} has area: {Area(rc)}");

			Square sq = new Square();
			sq.Width = 4;

			WriteLine($"{sq} has area: {Area(sq)}");
		}

		public static int Area(Rectangle r) => r.Width * r.Height;
	}
}