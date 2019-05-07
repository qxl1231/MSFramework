using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{

		public class PaymentType : Enumeration
		{
			/// <summary>
			/// 预付费
			/// </summary>
			public static readonly PaymentType PrePay = new PaymentType(1, nameof(PrePay).ToLowerInvariant());

			/// <summary>
			/// 后付费
			/// </summary>
			public static PaymentType AfterPay = new PaymentType(2, nameof(AfterPay).ToLowerInvariant());
	
			
			public PaymentType(int id, string name) : base(id, name)
			{
			}
		}
	
}