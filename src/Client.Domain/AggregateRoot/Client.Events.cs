using System;
using System.Collections.Generic;
using Client.Domain.AggregateRoot.ClientAggregateRoot;
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

		public string Type { get; }

		/// <summary>
		/// 城市
		/// </summary>

		public string City { get; }

		/// <summary>
		/// 省
		/// </summary>

		public string Province { get; }

		/// <summary>
		/// 国家
		/// </summary>

		public string Country { get; }

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


		public string State { get; }

		/// <summary>
		/// 启用/禁用
		/// </summary>

		public bool Active { get; }

		public List<ClientUser> ClientUsers { get; }

		public ClientCreatedEvent(
			string name, string shortName, string type, string city, string province,
			string country, string level, string paymentType, string scoringCycle, string state, bool active,
			List<ClientUser> clientUsers
		)
		{
			Name = name;
			ShortName = shortName;
			Type = type;
			City = city;
			Province = province;
			Country = country;
			Level = level;
			PaymentType = paymentType;
			ScoringCycle = scoringCycle;
			ClientUsers = clientUsers;
		}
	}

	public class ClientChangedEvent : AggregateEventBase
	{
		public string Name { get; }
		public string ShortName { get; }
		public string Type { get; }
		public string City { get; }
		public string Province { get; }
		public string Country { get; }
		public string Level { get; }
		public string PaymentType { get; }
		public string ScoringCycle { get; }

		public ClientChangedEvent(string name, string shortName, string type, string city, string province,
			string country, string level, string paymentType, string scoringCycle)
		{
			Name = name;
			ShortName = shortName;
			Type = type;
			City = city;
			Province = province;
			Country = country;
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
}