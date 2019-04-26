using System;
using System.Collections.Generic;
using System.Linq;
using Client.Domain.AggregateRoot;
using MSFramework.Data;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class Client : AggregateRootBase
	{
		// DDD Patterns comment
		// Using a private collection field, better for DDD Aggregate's encapsulation
		// so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
		// but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
		private readonly List<ClientUser> _clientUsers = new List<ClientUser>();


		/// <summary>
		/// 客户名称
		/// </summary>
		private string _name;

		/// <summary>
		/// 客户简称
		/// </summary>
		private string _shortName;

		/// <summary>
		/// 客户类型 -> 公墓基金、私募基金
		/// </summary>
		private string _type;

		/// <summary>
		/// 城市
		/// </summary>
		private string _city;

		/// <summary>
		/// 省
		/// </summary>
		private string _province;

		/// <summary>
		/// 国家
		/// </summary>
		private string _country;

		/// <summary>
		/// 优先级
		/// </summary>
		private string _level;

		/// <summary>
		/// 支付方式
		/// </summary>
		private string _paymentType;

		/// <summary>
		/// 打分周期
		/// </summary>
		private string _scoringCycle;

		/// <summary>
		/// 状态	销售线索、潜在客户、试用客户、活跃客户
		/// </summary>
		private string _state;

		/// <summary>
		/// 启用/禁用
		/// </summary>
		private bool _active;

		public IReadOnlyCollection<ClientUser> ClientUsers => _clientUsers;

		public Client(
			string name, string shortName, string type, string city, string province,
			string country, string level, string paymentType, string scoringCycle, string state, bool active
		)
		{
			ApplyAggregateEvent(new ClientCreatedEvent(name, shortName, type, city, province,
				country, level, paymentType, scoringCycle, state, active
			));
		}

		private void Apply(ClientCreatedEvent e)
		{
			_name = e.Name;
			_shortName = e.ShortName;
			_type = e.Type;
			_city = e.City;
			_province = e.Province;
			_country = e.Country;
			_level = e.Level;
			_paymentType = e.PaymentType;
			_scoringCycle = e.ScoringCycle;
		}

		private void Apply(ClientChangedEvent e)
		{
			_name = e.Name;
			_shortName = e.ShortName;
			_type = e.Type;
			_city = e.City;
			_province = e.Province;
			_country = e.Country;
			_level = e.Level;
			_paymentType = e.PaymentType;
			_scoringCycle = e.ScoringCycle;
		}

		private void Apply(ClientDeletedEvent e)
		{
		}

		private void Apply(EnableClientChangedEvent e)
		{
			_active = true;
		}

		private void Apply(DisableClientChangedEvent e)
		{
			_active = false;
		}

		/// <summary>
		/// 修改客户信息
		/// </summary>
		/// <param name="province"></param>
		/// <param name="country"></param>
		/// <param name="level"></param>
		/// <param name="name"></param>
		/// <param name="shortName"></param>
		/// <param name="type"></param>
		/// <param name="city"></param>
		/// <param name="paymentType"></param>
		/// <param name="scoringCycle"></param>
		/// <exception cref="ArgumentException"></exception>
		public void ChangeClient(string name, string shortName, string type, string city, string province,
			string country, string level, string paymentType, string scoringCycle)
		{
			ApplyAggregateEvent(new ClientChangedEvent(name, shortName, type, city, province,
				country, level, paymentType, scoringCycle));
		}


		public void EnableClient()
		{
			ApplyAggregateEvent(new EnableClientChangedEvent());
		}

		public void DisableClient()
		{
			ApplyAggregateEvent(new DisableClientChangedEvent());
		}

		public void DeleteClient()
		{
			ApplyAggregateEvent(new ClientDeletedEvent());
		}


		public void DeleteClientUser(Guid clientUserId)
		{
			ApplyAggregateEvent(new ClientUserDeletedEvent(clientUserId));
		}

		public void AddClientUser(ClientUser clientUser)
		{
			ApplyAggregateEvent(new ClientUserAddedEvent(clientUser));
		}

		private void Apply(ClientUserAddedEvent e)
		{
			Check.NotNull(e, nameof(e));
			_clientUsers.Add(e.NewClientUser);
		}

		/// <summary>
		/// 修改客户联系人信息
		/// </summary>
		/// <param name="newClientUser"></param>
		/// <exception cref="ArgumentException"></exception>
		public void UpdateClientUser(ClientUser newClientUser)
		{
//			Check.NotNull(newClientUser, nameof(newClientUser));
//
//			var oldClientUser = _clientUsers.FirstOrDefault(x => x.Id == newClientUser.Id);
//			Check.NotNull(oldClientUser, nameof(oldClientUser));
//
//			oldClientUser.SetEmail(newClientUser.GetEmail());

			ApplyAggregateEvent(new ClientUserUpdatedEvent(newClientUser));
		}

		private void Apply(ClientUserUpdatedEvent e)
		{
			Check.NotNull(e, nameof(e));

			var oldClientUser = _clientUsers.FirstOrDefault(x => x.Id == e.Id);
			Check.NotNull(oldClientUser, nameof(oldClientUser));

			oldClientUser = e.NewClientUser;
		}
	}
}