using System;
using MSFramework.Domain;

namespace Client.Domain.AggregateRoot
{
	public class ClientAccount : AggregateRootBase
	{
		private Guid _clientId;

		private string _name;

		/// <summary>
		/// 类型 临时 常规
		/// </summary>
		private string _type;

		/// <summary>
		/// 有效=1 无效=0
		/// </summary>
		private string _state;

		/// <summary>
		/// 开始日期
		/// </summary>
		private DateTime _start;

		/// <summary>
		/// 结束日期
		/// </summary>
		private DateTime _end;


		public Guid ClientId => _clientId;

		public string Name => _name;

		public string Type => _type;

		public string State => _state;

		public DateTime Start => _start;

		public DateTime End => _end;
	}
}