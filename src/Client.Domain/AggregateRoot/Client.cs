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
		private readonly List<ClientSale> _clientSales = new List<ClientSale>();
		private readonly List<ClientAccount> _clientAccounts = new List<ClientAccount>();

		//done:add sale 值类型
		//done:add account entity

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
		private ClientType _type;

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
		private ClientStateType _state;

		/// <summary>
		/// 启用/禁用
		/// </summary>
		private bool _active;

		public IReadOnlyCollection<ClientUser> ClientUsers => _clientUsers;
		public IReadOnlyCollection<ClientSale> ClientSales => _clientSales;
		public IReadOnlyCollection<ClientAccount> ClientAccounts => _clientAccounts;

		/// <summary>
		/// 创建客户
		/// </summary>
		/// <param name="name"></param>
		/// <param name="shortName"></param>
		/// <param name="type"></param>
		/// <param name="city"></param>
		/// <param name="province"></param>
		/// <param name="country"></param>
		/// <param name="level"></param>
		/// <param name="paymentType"></param>
		/// <param name="scoringCycle"></param>
		public Client(
			string name, string shortName, ClientType type, string city, string province,
			string country, string level, string paymentType, string scoringCycle
		)
		{
			ApplyAggregateEvent(new ClientCreatedEvent(name, shortName, type, city, province,
				country, level, paymentType, scoringCycle, ClientStateType.ActiveCustom, true
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
		public void ChangeClient(string name, string shortName, ClientType type, string city, string province,
			string country, string level, string paymentType, string scoringCycle)
		{
			ApplyAggregateEvent(new ClientChangedEvent(name, shortName, type, city, province,
				country, level, paymentType, scoringCycle));
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

		/// <summary>
		/// 启用客户
		/// </summary>
		public void EnableClient()
		{
			ApplyAggregateEvent(new EnableClientChangedEvent());
		}

		private void Apply(EnableClientChangedEvent e)
		{
			_active = true;
		}


		/// <summary>
		/// 禁用客户
		/// </summary>
		public void DisableClient()
		{
			ApplyAggregateEvent(new DisableClientChangedEvent());
		}

		private void Apply(DisableClientChangedEvent e)
		{
			_active = false;
		}


		/// <summary>
		/// 添加联系人
		/// </summary>
		/// <param name="clientUser"></param>
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
			ApplyAggregateEvent(new ClientUserUpdatedEvent(newClientUser));
		}

		private void Apply(ClientUserUpdatedEvent e)
		{
			Check.NotNull(e, nameof(e));

			var oldClientUser = _clientUsers.FirstOrDefault(x => x.Id == e.Id);
			Check.NotNull(oldClientUser, nameof(oldClientUser));

			oldClientUser = e.NewClientUser;
		}

		/// <summary>
		/// 启用联系人
		/// </summary>
		public void EnableClientUser(ClientUser clientUser)
		{
			ApplyAggregateEvent(new EnableClientUserChangedEvent());
		}

		private void Apply(EnableClientUserChangedEvent e)
		{
			Check.NotNull(e, nameof(e));
		}

		/// <summary>
		/// 禁用联系人
		/// </summary>
		public void DisableClientUser(ClientUser clientUser)
		{
			ApplyAggregateEvent(new DisableClientUserChangedEvent());
		}

		private void Apply(DisableClientUserChangedEvent e)
		{
			Check.NotNull(e, nameof(e));
		}


		/// <summary>
		/// 关联客户销售
		/// </summary>
		/// <param name="clientSale"></param>
		public void AddClientSale(ClientSale clientSale)
		{
			ApplyAggregateEvent(new ClientSaleAddedEvent(clientSale));
		}

		private void Apply(ClientSaleAddedEvent e)
		{
			Check.NotNull(e, nameof(e));
			_clientSales.Add(e.NewClientSale);
		}

		/// <summary>
		/// 取消关联客户销售
		/// </summary>
		/// <param name="clientSale"></param>
		public void RemoveClientSale(ClientSale clientSale)
		{
			ApplyAggregateEvent(new ClientSaleRemovedEvent(clientSale));
		}

		private void Apply(ClientSaleRemovedEvent e)
		{
			Check.NotNull(e, nameof(e));
			_clientSales.Remove(e.NewClientSale);
		}

		/// <summary>
		/// 添加客户账户
		/// </summary>
		/// <param name="clientAccount"></param>
		public void AddClientAccount(ClientAccount clientAccount)
		{
			ApplyAggregateEvent(new ClientAccountAddedEvent(clientAccount));
		}

		private void Apply(ClientAccountAddedEvent e)
		{
			Check.NotNull(e, nameof(e));
			_clientAccounts.Add(e.NewClientAccount);
		}

		/// <summary>
		/// 修改客户账户信息
		/// </summary>
		/// <param name="newClientAccount"></param>
		/// <exception cref="ArgumentException"></exception>
		public void UpdateClientAccount(ClientAccount newClientAccount)
		{
			ApplyAggregateEvent(new ClientAccountUpdatedEvent(newClientAccount));
		}

		private void Apply(ClientAccountUpdatedEvent e)
		{
			Check.NotNull(e, nameof(e));

			var oldClientAccount = _clientAccounts.FirstOrDefault(x => x.Id == e.Id);
			Check.NotNull(oldClientAccount, nameof(oldClientAccount));

			oldClientAccount = e.NewClientAccount;
		}

		/// <summary>
		/// 删除客户账户
		/// </summary>
		public void RemoveClientAccount(ClientAccount clientAccount)
		{
			ApplyAggregateEvent(new DisableClientAccountChangedEvent(clientAccount));
		}

		private void Apply(DisableClientAccountChangedEvent e)
		{
			Check.NotNull(e, nameof(e));
			_clientAccounts.Remove(e.ClientAccount);
		}
	}
}