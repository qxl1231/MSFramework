using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.API.Application.DTO;
using Client.API.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFramework.Domain;

namespace Client.API.Controllers
{
	[Route("api/v1/[controller]")]
	//[Authorize]
	[ApiController]
	public class ClientController : MSFrameworkControllerBase
	{
		private readonly ILogger _logger;
		private readonly IClientAppService _clientAppService;

		public ClientController(
			IClientAppService clientAppService,
			IMSFrameworkSession session, ILogger<ClientController> logger) : base(session)
		{
			_logger = logger;

			_clientAppService = clientAppService;
		}

		[HttpPost("")]
		public async Task<IActionResult> CreateOrderAsync()
		{
			var random = new Random();
			var count = random.Next(2, 5);
			await _clientAppService.CreateClient(new CreateClientDTO("富国基金公司", "富国基金", "富国基金", "富国基金", "富国基金", "富国基金",
				"富国基金", "富国基金"
				, "富国基金"
			));
			// FOR TEST
			return Ok();
		}

		[HttpDelete("{clientId}")]
		public async Task<IActionResult> DeleteOrderAsync(Guid clientId)
		{
			await _clientAppService.DeleteClient(new DeleteClientDTO()
			{
				ClientId = clientId
			});
			return Ok();
		}


		#region QUERY

		[HttpGet("{orderId}")]
		public async Task<ActionResult> GetOrderAsync(string orderId)
		{
			var order = await _clientAppService.GetClientAsync(Guid.NewGuid());
			return Ok(order);
		}

		#endregion
	}
}