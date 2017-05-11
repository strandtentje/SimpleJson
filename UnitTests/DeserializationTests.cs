using System;
using NUnit.Framework;
using System.Collections;
using SimpleJson.Transcoder;

namespace SimpleJson.UnitTests
{
	[TestFixture ()]
	public class DeserializationTests
	{
		[TestCase ()]
		public void DeserializationTest ()
		{
			string json = "[{\"stringtest\":\"hello world\",\"nulltest\":null,\"collection\":[-1,null,24.565657576,\"blah\",false]}]";
			ArrayList arrayList = JsonSerializer.DeserializeString (json) as ArrayList;
			Hashtable hashtable = arrayList [0] as Hashtable;
			string stringtest = hashtable ["stringtest"].ToString ();
			object nulltest = hashtable ["nulltest"];
			ArrayList collection = hashtable ["collection"] as ArrayList;
			long a = (long)collection [0];
			object b = collection [1];
			double c = (double)collection [2];
			string d = collection [3].ToString ();
			bool e = (bool)collection [4];

			Assert.AreEqual (1, arrayList.Count);
			Assert.AreEqual (3, hashtable.Count);
			Assert.AreEqual ("hello world", stringtest);
			Assert.IsNull (nulltest);
			Assert.AreEqual (5, collection.Count);
			Assert.AreEqual (-1, a);
			Assert.IsNull (b);
			Assert.AreEqual (24.565657576, c);
			Assert.AreEqual ("blah", d);
			Assert.IsFalse (e);
		}
	}
}

