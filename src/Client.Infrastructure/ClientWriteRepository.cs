using MSFramework.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore.Repository;
using Client.Domain;
using Client.Domain.AggregateRoot;
using ClientEntity=Client.Domain.AggregateRoot.Client;

namespace Client.Infrastructure
{
	public class ClientWriteRepository : EfWriteRepository<ClientEntity>, IClientWriteRepository
	{
		public ClientWriteRepository(DbContextFactory dbContextFactory) : base(dbContextFactory)
		{
		}
	}
}