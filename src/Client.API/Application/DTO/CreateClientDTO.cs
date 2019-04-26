using System.Collections.Generic;

namespace Client.API.Application.DTO
{
	public class CreateClientDTO
	{
		public string UserId { get; set; }

		public string City { get; set; }

		public string Street { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		public string ZipCode { get; set; }

		public string Description { get; set; }


		public CreateClientDTO()
		{
		}

		public CreateClientDTO( string userId, string city,
			string street, string state, string country, string zipcode, string description)
		{
			UserId = userId;

			City = city;
			Street = street;
			State = state;
			Country = country;
			ZipCode = zipcode;
			Description = description;
		}
	}
}