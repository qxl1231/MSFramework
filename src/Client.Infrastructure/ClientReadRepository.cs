using MSFramework.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore.Repository;
using Client.Domain;
using ClientEntity=Client.Domain.AggregateRoot.Client;

namespace Client.Infrastructure
{
	public class ClientReadRepository : EfReadRepository<ClientEntity>,IClientReadRepository
	{
		public ClientReadRepository(DbContextFactory dbContextFactory) : base(dbContextFactory)
		{
		}
	}
}