using System;
using System.Collections.Generic;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientSale : ValueObject
	{
		public Guid ClientId { get; private set; }
		public Guid SaleId { get; private set; }

		private ClientSale()
		{
		}

		public ClientSale(Guid clientId, Guid saleId)
		{
			ClientId = clientId;
			SaleId = saleId;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			// Using a yield return statement to return each element one at a time
			yield return ClientId;
			yield return SaleId;
		}
	}
}