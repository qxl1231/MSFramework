using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore.Repository;

namespace MSFramework.EventSouring.EntityFrameworkCore
{
	public class EfEventStore : IEventStore
	{
		private readonly DbSet<EventHistory> _table;
		private readonly DbContext _dbContext;

		public EfEventStore(DbContextFactory factory)
		{
			_dbContext = factory.GetDbContext<EventHistory>();
			_table = _dbContext.Set<EventHistory>();
		}

		public async Task<IEnumerable<EventHistory>> GetEventsAsync(string aggregateId, long @from)
		{
			return await _table.Where(x => x.Version > from && x.AggregateId == aggregateId).ToListAsync();
		}

		public async Task AddEventAsync(params EventHistory[] events)
		{
			foreach (var @event in events)
			{
				await _table.AddAsync(@event);
			}

			await _dbContext.SaveChangesAsync();
		}
	}
}