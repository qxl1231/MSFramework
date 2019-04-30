using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.API.Application.DTO;
using Microsoft.Extensions.Logging;
using MSFramework;
using MSFramework.Application;
using MSFramework.Domain;
using Client.Domain;
using Client.Domain.AggregateRoot;

namespace Client.API.Application.Services
{
	public class ClientAppService : ApplicationServiceBase, IClientAppService
	{
		private readonly IClientReadRepository _readRepository;
		private readonly IClientWriteRepository _writeRepository;

		public ClientAppService(IMSFrameworkSession session, IClientReadRepository readRepository,
			IClientWriteRepository writeRepository,
			ILogger<ClientAppService> logger) : base(session, logger)
		{
			_readRepository = readRepository;
			_writeRepository = writeRepository;
		}

//		public async Task DeleteClient(DeleteClientDTO dto)
//		{
//			var item = await _writeRepository.GetAsync(dto.ClientId);
//			item.DeleteClient();
//		}

		public async Task ChangeClient(UpdateClientDTO dto)
		{
			var item = await _writeRepository.GetAsync(dto.ClientId);
//			item.ChangeClient(dto);
		}
		
		public async Task EnableClient(Guid clientId)
		{
			var item = await _writeRepository.GetAsync(clientId);
//			item.ChangeClient(dto);
		}
		
		public async Task DisableClient(Guid clientId)
		{
			var item = await _writeRepository.GetAsync(clientId);
//			item.ChangeClient(dto);
		}

		public async Task CreateClient(CreateClientDTO dto)
		{
			var client = new Domain.AggregateRoot.Client(
				dto.Name,dto.ShortName,dto.Type,dto.City,dto.Province,
				dto.Country,dto.Level,dto.PaymentType,dto.ScoringCycle);
//				client.RegisterDomainEvent(new ClientStartedEvent(Session.UserId, client.Id));
			await _writeRepository.InsertAsync(client);
		}

		public async Task<List<Domain.AggregateRoot.Client>> GetAllClientsAsync()
		{
			var clients = await _readRepository.GetAllListAsync();
			return clients;
		}

		public async Task<Domain.AggregateRoot.Client> GetClientAsync(Guid clientId)
		{
			var client = await _readRepository.GetAsync(clientId);
			return client;
		}
	}
}