using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientType : Enumeration
	{
		/// <summary>
		/// 公墓基金
		/// </summary>
		public static readonly ClientType PublicFund = new ClientType(1, nameof(PublicFund).ToLowerInvariant());

		/// <summary>
		/// 私募基金
		/// </summary>
		public static ClientType PrivateFund = new ClientType(2, nameof(PrivateFund).ToLowerInvariant());

		public ClientType(int id, string name) : base(id, name)
		{
		}
	}
}