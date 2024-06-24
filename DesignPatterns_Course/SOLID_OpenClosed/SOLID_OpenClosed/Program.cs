namespace DesignPatterns
{
	public enum Color
	{
		Red, Green, Blue
	}

	public enum Size
	{
		Small, Medium, Large, Huge
	}

	public class Product
	{
		public string Name;
		public Color Color;
		public Size Size;

		public Product(string name, Color color, Size size)
		{
			Name = name;
			Color = color;
			Size = size;
		}
	}

	public class ProductFilter
	{
		public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
		{
			foreach (Product product in products)
			{
				if (product.Size == size)
				{
					yield return product;
				}
			}
		}
	}

	public static class Program
	{
		public static void Main(string[] args)
		{
			var apple = new Product("Apple", Color.Green, Size.Small);
			var tree = new Product("Tree", Color.Green, Size.Large);
			var house = new Product("House", Color.Blue, Size.Huge);

			Product[] products = { apple, tree, house };

			var productFilter = new ProductFilter();
		}
	}
}