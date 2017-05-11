using NUnit.Framework;
using System;
using SimpleJson.Transcoder;

namespace SimpleJson.UnitTests
{
	[TestFixture ()]
	public class DateTests
	{
		[Test ()]
		public void DateTest ()
		{
			DateTime testTime = new DateTime (2015, 04, 22, 11, 56, 39, 456);
			JsonSerializer dataSerializer = new JsonSerializer (DateTimeFormat.ISO8601);
			string jsonString = dataSerializer.Serialize (testTime);
			string deserializedJsonString = (string)dataSerializer.Deserialize (jsonString);
			DateTime convertTime = DateTimeExtensions.FromIso8601 (deserializedJsonString);

			Assert.AreEqual (testTime, convertTime);
		}
	}
}

