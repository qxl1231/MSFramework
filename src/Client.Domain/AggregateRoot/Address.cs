using System.Collections.Generic;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class Address : ValueObject
	{
		public string City { get;  set; }
		public string Province { get;  set; }
		public string Country { get;  set; }

		private Address()
		{
		}

		public Address(string city, string province, string country)
		{
			City = city;
			Province = province;
			Country = country;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			// Using a yield return statement to return each element one at a time
			yield return City;
			yield return Province;
			yield return Country;
		}
	}
}