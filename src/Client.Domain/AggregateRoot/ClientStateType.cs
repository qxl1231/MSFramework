using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientStateType: Enumeration
	{
		/// <summary>
		/// 状态	销售线索、
		/// </summary>
		public static ClientStateType SaleLeads = new ClientStateType(1, nameof(SaleLeads).ToLowerInvariant());
		
		/// <summary>
		/// 状态	潜在客户、
		/// </summary>
		public static ClientStateType ProspectiveCustomer = new ClientStateType(2, nameof(ProspectiveCustomer).ToLowerInvariant());
		
		/// <summary>
		/// 状态	试用客户、
		/// </summary>
		public static ClientStateType TryCustom = new ClientStateType(3, nameof(TryCustom).ToLowerInvariant());
		
		/// <summary>
		/// 状态	活跃客户
		/// </summary>
		public static ClientStateType ActiveCustom = new ClientStateType(4, nameof(ActiveCustom).ToLowerInvariant());
		
		public ClientStateType(int id, string name) : base(id, name)
		{
		}
	}
}