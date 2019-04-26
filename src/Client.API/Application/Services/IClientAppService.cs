using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.API.Application.DTO;
using MSFramework.Application;
using ClientEntity=Client.Domain.AggregateRoot.Client;

namespace Client.API.Application.Services
{
	public interface IClientAppService : IApplicationService
	{
		Task DeleteClient(DeleteClientDTO dto);

		Task ChangeClient(UpdateClientDTO dto);

		Task CreateClient(CreateClientDTO dto);
		
		Task<List<ClientEntity>> GetAllClientsAsync();

		Task<ClientEntity> GetClientAsync(Guid orderId);
	}
}