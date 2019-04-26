using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework.EventBus;
using Ordering.API.Application.DTO;
using Ordering.API.Application.Event;
using Ordering.API.Application.Services;

namespace Ordering.API.Application.EventHandler
{
	public class UserCheckoutAcceptedEventHandler : IEventHandler<UserCheckoutAcceptedEvent>
	{
		private readonly IOrderingAppService _commandBus;
		private readonly ILogger _logger;

		public UserCheckoutAcceptedEventHandler(IOrderingAppService commandBus,
			ILogger<UserCheckoutAcceptedEventHandler> logger)
		{
			_commandBus = commandBus;
			_logger = logger;
		}

		public async Task Handle(UserCheckoutAcceptedEvent @event)
		{
			var dto = new CreateOrderDTO(@event.OrderItems, @event.UserId, @event.City, @event.Street,
				@event.State, @event.Country, @event.ZipCode, @event.Description);
			// IdentifiedCommand<> 必须保证只执行一次
			await _commandBus.CreateOrder(dto);
		}
	}
}