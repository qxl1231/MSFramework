using System;
using MSFramework.Domain.Event;

namespace Client.API.Application.Event
{
	/// <summary>
	/// 发送到外部的领域事件
	/// </summary>
	public class ClientStartedEvent : DomainEventBase<Guid>
	{
		public string UserId { get; }
		
		public Guid ClientId { get; }

		public ClientStartedEvent(string userId, Guid clientId)
		{
			UserId = userId;
			ClientId = clientId;
		}
		
	}
}