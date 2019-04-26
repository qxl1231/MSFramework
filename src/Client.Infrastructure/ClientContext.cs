using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSFramework.EntityFrameworkCore;
using MSFramework.EventBus;

namespace Client.Infrastructure
{
	public class ClientContext : DbContextBase
	{
		public ClientContext(DbContextOptions options, IEntityConfigurationTypeFinder typeFinder,
			IEventBus eventBus,
			ILoggerFactory loggerFactory) : base(options, typeFinder, eventBus,
			loggerFactory)
		{
		}
	}
}