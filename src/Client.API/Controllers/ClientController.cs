using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.API.Application.DTO;
using Client.API.Application.Services;
using Client.Domain.AggregateRoot;
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
		public async Task<IActionResult> CreateClient()
		{
			await _clientAppService.CreateClient(new CreateClientDTO("富国基金公司", "富国基金", ClientType.PublicFund, "富国基金", "富国基金", "富国基金",
				Level.A, PaymentType.PrePay
				, "1,2,3,4"
			));
			// FOR TEST
			return Ok();
		}

		[HttpPut("disable/{clientId}")]
		public async Task<IActionResult> DisableClientAsync(Guid clientId)
		{
			await _clientAppService.DisableClient(clientId);
			return Ok();
		}
		
		[HttpPut("enable/{clientId}")]
		public async Task<IActionResult> EnableClientAsync(Guid clientId)
		{
			await _clientAppService.EnableClient(clientId);
			return Ok();
		}



		#region QUERY

		[HttpGet("{clientId}")]
		public async Task<ActionResult> GetClientAsync(Guid clientId)
		{
			var order = await _clientAppService.GetClientAsync(clientId);
			return Ok(order);
		}

		#endregion
	}
}