using System;
using System.Collections.Generic;
using Client.Domain.AggregateRoot;
using MSFramework.Domain.Event;

namespace Client.Domain.AggregateRoot
{
	public class ClientDeletedEvent : AggregateEventBase
	{
	}

	public class ClientUserDeletedEvent : AggregateEventBase
	{
		public Guid ClientUserId { get; }

		public ClientUserDeletedEvent(Guid clientUserId)
		{
			ClientUserId = clientUserId;
		}
	}

	public class ClientCreatedEvent : AggregateEventBase
	{
		/// <summary>
		/// 客户名称
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// 客户简称
		/// </summary>
		public string ShortName { get; }

		/// <summary>
		/// 客户类型 -> 公墓基金、私募基金
		/// </summary>
		public ClientType Type { get; }
		
		/// <summary>
		/// 地区
		/// </summary>
		public Address Address{ get; }

		/// <summary>
		/// 优先级
		/// </summary>
		public string Level { get; }

		/// <summary>
		/// 支付方式
		/// </summary>
		public string PaymentType { get; }

		/// <summary>
		/// 打分周期
		/// </summary>
		public string ScoringCycle { get; }

		/// <summary>
		/// 状态	销售线索、潜在客户、试用客户、活跃客户
		/// </summary>

		public ClientStateType State { get; }

		/// <summary>
		/// 启用/禁用
		/// </summary>

		public bool Active { get; }

		public List<ClientUser> ClientUsers { get; }

		public ClientCreatedEvent(
			string name, string shortName, ClientType type, Address address,
			 string level, string paymentType, string scoringCycle, ClientStateType state, bool active
		)
		{
			Name = name;
			ShortName = shortName;
			Type = type;
			Address = address;
			Level = level;
			PaymentType = paymentType;
			ScoringCycle = scoringCycle;
		}
	}

	public class ClientChangedEvent : AggregateEventBase
	{
		public string Name { get; }
		public string ShortName { get; }
		public ClientType Type { get; }
		
		public Address Address{ get; }
		public string Level { get; }
		public string PaymentType { get; }
		public string ScoringCycle { get; }

		public ClientChangedEvent(string name, string shortName, ClientType type, 
			Address address, string level, string paymentType, string scoringCycle)
		{
			Name = name;
			ShortName = shortName;
			Type = type;
			Address = address;
			
			Level = level;
			PaymentType = paymentType;
			ScoringCycle = scoringCycle;
		}
	}

	public class EnableClientChangedEvent : AggregateEventBase
	{
		public EnableClientChangedEvent()
		{
		}
	}

	public class DisableClientChangedEvent : AggregateEventBase
	{
		public DisableClientChangedEvent()
		{
			//check client ,get client

			//set active
		}
	}

	public class EnableClientUserChangedEvent : AggregateEventBase
	{
		public ClientUser ClientUser { get; }

		public EnableClientUserChangedEvent()
		{
		}
	}

	public class DisableClientUserChangedEvent : AggregateEventBase
	{
		public ClientUser ClientUser { get; }

		public DisableClientUserChangedEvent()
		{
			//check client ,get client

			//set active
		}
	}


	public class ClientUserAddedEvent : AggregateEventBase
	{
		public ClientUser NewClientUser { get; }

		public ClientUserAddedEvent(ClientUser newClientUser)
		{
			NewClientUser = newClientUser;
		}
	}

	public class ClientUserUpdatedEvent : AggregateEventBase
	{
		public ClientUser NewClientUser { get; }

		public ClientUserUpdatedEvent(ClientUser newClientUser)
		{
			NewClientUser = newClientUser;
		}
	}

	public class ClientSaleAddedEvent : AggregateEventBase
	{
		public ClientSale NewClientSale { get; }

		public ClientSaleAddedEvent(ClientSale newClientSale)
		{
			NewClientSale = newClientSale;
		}
	}

	public class ClientSaleRemovedEvent : AggregateEventBase
	{
		public ClientSale NewClientSale { get; }

		public ClientSaleRemovedEvent(ClientSale newClientSale)
		{
			NewClientSale = newClientSale;
		}
	}

	public class ClientAccountAddedEvent : AggregateEventBase
	{
		public ClientAccount NewClientAccount { get; }

		public ClientAccountAddedEvent(ClientAccount newClientAccount)
		{
			NewClientAccount = newClientAccount;
		}
	}

	public class ClientAccountUpdatedEvent : AggregateEventBase
	{
		public ClientAccount NewClientAccount { get; }

		public ClientAccountUpdatedEvent(ClientAccount newClientAccount)
		{
			NewClientAccount = newClientAccount;
		}
	}

	public class DisableClientAccountChangedEvent : AggregateEventBase
	{
		public ClientAccount ClientAccount { get; }

		public DisableClientAccountChangedEvent(ClientAccount clientAccount)
		{
			ClientAccount = clientAccount;
		}
	}
}