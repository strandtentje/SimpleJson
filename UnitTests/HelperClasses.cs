using System;

namespace SimpleJson.UnitTests
{
	public class Person
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public DateTime Birthday { get; set; }

		public int ID { get; set; }

		public string[] ArrayProperty { get; set; }

		public Person Friend { get; set; }
	}

	public abstract class AbstractClass
	{
		public int ID { get; set; }

		public abstract string Test { get; }

		public virtual string Test2 { get { return "test2"; } }
	}

	public class RealClass : AbstractClass
	{
		public override string Test { get { return "test"; } }
	}
}

