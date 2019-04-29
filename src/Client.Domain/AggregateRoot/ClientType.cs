using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientType: Enumeration
	{
		
			/// <summary>
			/// 公墓基金
			/// </summary>
			public static ClientType PublicFund = new ClientType(1, nameof(PublicFund).ToLowerInvariant());
		
			/// <summary>
			/// 私募基金
			/// </summary>
			public static ClientType PrivateFund = new ClientType(2, nameof(PrivateFund).ToLowerInvariant());
		
			/// <summary>
			/// 电话
			/// </summary>
			public static ClientType Tel = new ClientType(1, nameof(Tel).ToLowerInvariant());
		
			/// <summary>
			/// 会议
			/// </summary>
			public static ClientType Conference = new ClientType(1, nameof(Conference).ToLowerInvariant());
		
			public ClientType(int id, string name) : base(id, name)
			{
			}
	}
}