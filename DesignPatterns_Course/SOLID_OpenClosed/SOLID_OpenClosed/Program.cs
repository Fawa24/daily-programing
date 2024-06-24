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

	public interface ISpecification<T>
	{
		bool IsSatisfied(T t);
	}

	public interface IFilter<T>
	{
		IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
	}

	public class ColorSpecification : ISpecification<Product>
	{
		private Color color;

		public ColorSpecification(Color color)
		{
			this.color = color;
		}

		public bool IsSatisfied(Product t)
		{
			return t.Color == color;
		}
	}

	public class SizeSpecification : ISpecification<Product>
	{
		private Size size;

		public SizeSpecification(Size size)
		{
			this.size = size;
		}

		public bool IsSatisfied(Product t)
		{
			return t.Size == size;
		}
	}

	public class AndSpecification : ISpecification<Product>
	{
		ISpecification<Product> first, second;

		public AndSpecification(ISpecification<Product> first, ISpecification<Product> second)
		{
			this.first = first;
			this.second = second;
		}

		public bool IsSatisfied(Product t)
		{
			return first.IsSatisfied(t) && second.IsSatisfied(t);
		}
	}

	public class BetterFilter : IFilter<Product>
	{
		public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
		{
			foreach (Product product in items)
			{
				if (spec.IsSatisfied(product))
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

			var betterProductFilter = new BetterFilter();

			Console.WriteLine("Green products (new):");

			foreach (var p in betterProductFilter.Filter(products, new ColorSpecification(Color.Green)))
			{
				Console.WriteLine($"# - {p.Name} is green");
			}

			Console.WriteLine("\nHuge blue items:");

			foreach (var i in betterProductFilter.Filter(products, new AndSpecification(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Huge))))
			{
				Console.WriteLine($"# - {i.Name} is huge and blue");
			}
		}
	}
}