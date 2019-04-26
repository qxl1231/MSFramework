using System;
using System.Collections.Generic;
using MSFramework.Domain.Event;
using Client.API.Application.DTO;

namespace Client.API.Application.Event
{
	public class UserCheckoutAcceptedEvent : DomainEventBase<Guid>
	{
		public string UserId { get; }

		public string City { get; set; }

		public string Street { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		public string ZipCode { get; set; }

		public string Description { get; }


		public UserCheckoutAcceptedEvent( string userId, string city, string street,
			string state, string country, string zipCode, string description)
		{
			UserId = userId;
			City = city;
			Street = street;
			State = state;
			Country = country;
			ZipCode = zipCode;
			Description = description;
		}
	}
}