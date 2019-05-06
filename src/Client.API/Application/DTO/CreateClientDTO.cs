using System.Collections.Generic;
using Client.Domain.AggregateRoot;

namespace Client.API.Application.DTO
{
	public class CreateClientDTO
	{
		/// <summary>
		/// 客户名称
		/// </summary>


		public string Name { get; set; }

		/// <summary>
		/// 客户简称
		/// </summary>


		public string ShortName { get; set; }

		/// <summary>
		/// 客户类型 -> 公墓基金、私募基金
		/// </summary>


		public ClientType Type { get; set; }

		/// <summary>
		/// 城市
		/// </summary>

		public string City { get; set; }

		/// <summary>
		/// 省
		/// </summary>

		public string Province { get; set; }

		/// <summary>
		/// 国家
		/// </summary>

		public string Country { get; set; }

		/// <summary>
		/// 优先级
		/// </summary>


		public string Level { get; set; }

		/// <summary>
		/// 支付方式
		/// </summary>


		public string PaymentType { get; set; }

		/// <summary>
		/// 打分周期
		/// </summary>

		public string ScoringCycle { get; set; }

		/// <summary>
		/// 状态	销售线索、潜在客户、试用客户、活跃客户
		/// </summary>


		public ClientStateType State { get; set; }

		/// <summary>
		/// 启用/禁用
		/// </summary>

		public bool Active { get; set; }

		public CreateClientDTO()
		{
		}

		public CreateClientDTO(string name, string shortName, ClientType type, string city, string province,
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
}