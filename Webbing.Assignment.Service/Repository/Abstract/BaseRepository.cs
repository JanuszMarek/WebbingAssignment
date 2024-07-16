using Microsoft.EntityFrameworkCore;
using Webbing.Assignment.Service.Entities.Abstract;

namespace Webbing.Assignment.Service.Repository.Abstract
{
	public abstract class BaseRepository<T, TContext> : IBaseRepository where T : class, IEntity
		where TContext : DbContext
	{
		protected readonly TContext context;
		protected readonly DbSet<T> dbSet;

		public BaseRepository(TContext dbContext)
		{
			context = dbContext;
			dbSet = dbContext.Set<T>();
		}

		public async Task<int> SaveChanges()
		{
			return await context.SaveChangesAsync();
		}
	}
}
