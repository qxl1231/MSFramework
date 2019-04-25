using System;
using System.Collections.Generic;
using Client.Domain.AggregateRoot.ClientAggregateRoot;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class Client : AggregateRootBase
	{
		private bool _isDeleted;

		/// <summary>
		/// 客户名称
		/// </summary>
		private string Name;

		/// <summary>
		/// 客户简称
		/// </summary>
		private string ShortName;

		/// <summary>
		/// 客户类型 -> 公墓基金、私募基金
		/// </summary>
		private string Type;

		/// <summary>
		/// 城市
		/// </summary>
		private string City;

		/// <summary>
		/// 省
		/// </summary>
		private string Province;

		/// <summary>
		/// 国家
		/// </summary>
		private string Country;

		/// <summary>
		/// 优先级
		/// </summary>
		private string Level;

		/// <summary>
		/// 支付方式
		/// </summary>
		private string PaymentType;

		/// <summary>
		/// 打分周期
		/// </summary>
		private string ScoringCycle;

		/// <summary>
		/// 状态	销售线索、潜在客户、试用客户、活跃客户
		/// </summary>
		private string State;

		/// <summary>
		/// 启用/禁用
		/// </summary>
		private bool Active;

		public ClientUser ClientUser { get; private set; }


		public Client(
			string name, string shortName, string type, string city, string province,
			string country, string level, string paymentType, string scoringCycle, string state, bool active,
			List<ClientUser> clientUsers
		)
		{
			ApplyAggregateEvent(new ClientCreatedEvent(name, shortName, type, city, province,
				country, level, paymentType, scoringCycle, state, active,
				clientUsers));
		}

		private void Apply(ClientCreatedEvent e)
		{
			Version = e.Version;
			Id = e.AggregateId;
			Name = e.Name;
			ShortName = e.ShortName;
			Type = e.Type;
			City = e.City;
			Province = e.Province;
			Country = e.Country;
			Level = e.Level;
			PaymentType = e.PaymentType;
			ScoringCycle = e.ScoringCycle;
		}

		private void Apply(ClientUserChangedEvent e)
		{
			Version = e.Version;
			ClientUser = e.NewClientUser;
		}

		private void Apply(ClientDeletedEvent e)
		{
			Version = e.Version;
			_isDeleted = true;
		}

		/// <summary>
		/// 修改客户信息
		/// </summary>
		/// <param name="newClient"></param>
		/// <exception cref="ArgumentException"></exception>
		public void ChangeClient(Client newClient)
		{
			if (newClient == null)
			{
				throw new ArgumentException(nameof(newClient));
			}

			ApplyAggregateEvent(new ClientChangedEvent(newClient));
		}
		/// <summary>
		/// 修改客户联系人信息
		/// </summary>
		/// <param name="newClientUser"></param>
		/// <exception cref="ArgumentException"></exception>
		public void ChangeClientUser(ClientUser newClientUser)
		{
			if (newClientUser == null)
			{
				throw new ArgumentException(nameof(newClientUser));
			}

			ApplyAggregateEvent(new ClientUserChangedEvent(newClientUser));
		}
		
		public void EnableClient(Guid clientId)
		{
			if (clientId == null)
			{
				throw new ArgumentException(nameof(clientId));
			}

			ApplyAggregateEvent(new EnableClientChangedEvent(clientId));
		}

		public void DisableClient(Guid clientId)
		{
			if (clientId == null)
			{
				throw new ArgumentException(nameof(clientId));
			}

			ApplyAggregateEvent(new DisableClientChangedEvent(clientId));
		}
		public void DeleteClient()
		{
			ApplyAggregateEvent(new ClientDeletedEvent());
		}

		
		public void DeleteClientUser()
		{
			ApplyAggregateEvent(new ClientUserDeletedEvent());
		}

		
	}
}