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

	// low-level module
	public class Relationships
	{
		private List<(Person, Relationship, Person)> relationships = new List<(Person, Relationship, Person)>();

		public void AddParentAndChild(Person parent, Person child)
		{
			relationships.Add((parent, Relationship.Parent, child));
			relationships.Add((child, Relationship.Child, parent));
		}

		public List<(Person, Relationship, Person)> Relations => relationships;
	}

	// high-level module
	public class Research
	{
		public Research(Relationships relationships)
		{
			var relations = relationships.Relations;
			foreach (var rel in relations.Where(x => x.Item1.Name == "Jhon" && x.Item2 == Relationship.Parent))
			{
                Console.WriteLine($"Jhon has a child called {rel.Item3.Name}");
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