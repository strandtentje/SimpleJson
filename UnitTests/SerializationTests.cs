using NUnit.Framework;
using System;
using System.Collections;
using SimpleJson.Transcoder;

namespace SimpleJson.UnitTests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void EscapeTest ()
		{				
			Hashtable hashTable = new Hashtable ();
			hashTable.Add ("quote", "---\"---");
			hashTable.Add ("backslash", "---\\---");
			Assert.AreEqual (
				"{\"quote\":\"---\\\"---\",\"backslash\":\"---\\\\---\"}",
				JsonSerializer.SerializeObject (hashTable)
			);
		}

		[Test ()]
		public void AbstractionTest ()
		{
			AbstractClass a = new RealClass () { ID = 12 };
			Assert.AreEqual ("{\"Test2\":\"test2\",\"ID\":12,\"Test\":\"test\"}", JsonSerializer.SerializeObject (a));

			RealClass b = new RealClass () { ID = 12 };
			Assert.AreEqual ("{\"Test2\":\"test2\",\"ID\":12,\"Test\":\"test\"}", JsonSerializer.SerializeObject (b));
		}

		[Test ()]
		public void ClassTest ()
		{
			Person friend = new Person () {
				FirstName = "Bob",
				LastName = "Smith",
				Birthday = new DateTime (1983, 7, 3),
				ID = 2,
				Address = "123 Some St",
				ArrayProperty = new string[] { "hi", "planet" },
			};
			Person person = new Person () { 
				FirstName = "John", 
				LastName = "Doe", 
				Birthday = new DateTime (1988, 4, 23), 
				ID = 27, 
				Address = null,
				ArrayProperty = new string[] { "hello", "world" },
				Friend = friend
			};
			string json = JsonSerializer.SerializeObject (person);
			string correctValue = "{\"Address\":null,\"ArrayProperty\":[\"hello\",\"world\"],\"ID\":27,\"Birthday\":\"1988-04-23T00:00:00.000Z\",\"LastName\":\"Doe\",\"Friend\""
			                      + ":{\"Address\":\"123 Some St\",\"ArrayProperty\":[\"hi\",\"planet\"],\"ID\":2,\"Birthday\":\"1983-07-03T00:00:00.000Z\",\"LastName\":\"Smith\",\"Friend\":null,\"FirstName\":\"Bob\"}"
			                      + ",\"FirstName\":\"John\"}";

			Assert.AreEqual (correctValue, json);
		}

		[Test ()]
		public void DirectTest ()
		{
			ICollection collection = new ArrayList () { 1, null, 2, "blah", false };
			Hashtable hashtable = new Hashtable ();
			hashtable.Add ("collection", collection);
			hashtable.Add ("nulltest", null);
			hashtable.Add ("stringtest", "hello world");
			object[] array = new object[] { hashtable };
			string json = JsonSerializer.SerializeObject (array);
			string correctValue = "[{\"stringtest\":\"hello world\",\"nulltest\":null,\"collection\":[1,null,2,\"blah\",false]}]";

			Assert.AreEqual (correctValue, json);
		}
	}
}

