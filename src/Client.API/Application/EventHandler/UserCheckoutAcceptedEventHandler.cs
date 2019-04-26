using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSFramework.EventBus;
using Client.API.Application.DTO;
using Client.API.Application.Event;
using Client.API.Application.Services;

namespace Client.API.Application.EventHandler
{
	public class UserCheckoutAcceptedEventHandler : IEventHandler<UserCheckoutAcceptedEvent>
	{
		private readonly IClientAppService _commandBus;
		private readonly ILogger _logger;

		public UserCheckoutAcceptedEventHandler(IClientAppService commandBus,
			ILogger<UserCheckoutAcceptedEventHandler> logger)
		{
			_commandBus = commandBus;
			_logger = logger;
		}

		public async Task Handle(UserCheckoutAcceptedEvent @event)
		{
//			var dto = new CreateClientDTO( @event.UserId, @event.City, @event.Street,
//				@event.State, @event.Country, @event.ZipCode, @event.Description);
			// IdentifiedCommand<> 必须保证只执行一次
//			await _commandBus.CreateClient(dto);
		}
	}
}