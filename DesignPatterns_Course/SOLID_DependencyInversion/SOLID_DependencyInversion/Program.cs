namespace DesignPatterns
{
	public enum Relationship
	{
		Parent, Child, Sibling
	}

	public class Person
	{
		public string Name = null!;
	}

	public interface IRelationshipBrowser
	{
		IEnumerable<Person> FindAllChildrenOf(string parentName);
	}

	// low-level module
	public class Relationships : IRelationshipBrowser
	{
		private List<(Person, Relationship, Person)> relationships = new List<(Person, Relationship, Person)>();

		public void AddParentAndChild(Person parent, Person child)
		{
			relationships.Add((parent, Relationship.Parent, child));
			relationships.Add((child, Relationship.Child, parent));
		}

		public IEnumerable<Person> FindAllChildrenOf(string parentName)
		{
			foreach (var rel in relationships.Where(x => x.Item1.Name == parentName && x.Item2 == Relationship.Parent))
			{
				yield return rel.Item3;
			}
		}
	}

	// high-level module
	public class Research
	{
		public Research(IRelationshipBrowser browser)
		{
			foreach (var p in browser.FindAllChildrenOf("Jhon"))
			{
				Console.WriteLine($"Jhon has children named {p.Name}");
			}
		}

		public static void Main(string[] args)
		{
			var parent = new Person { Name = "Jhon" };
			var child1 = new Person { Name = "Chris" };
			var child2 = new Person { Name = "Mary" };

			var relationships = new Relationships();
			relationships.AddParentAndChild(parent, child1);
			relationships.AddParentAndChild(parent, child2);

			new Research(relationships);
		}
	}
}